using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    /*--Properties of the class--*/

    // The player's score
    private int playerScore;

    // The amount of balls the player has left
    private int playerBallCount = 3;

    // Did the game start
    public bool didGameStart = false;

    // Is the game over
    public bool isGameOver = false;

    // Is the game paused
    public bool isGamePaused = false;

    // Reference to the gameOverAudioSource
    private AudioSource gameOverAudioSource;

    // The message of the game over screen
    string gameOverScreenMessage;

    /*-Game Rules Properties-*/
    [Header("Game Rules Properties"), SerializeField]
    private int targetScore = 500;

    /*-Timer Properties-*/
    [Header("Timer Properties"), SerializeField]
    public int timerMinutes;

    [SerializeField]
    public int timerSeconds;

    /*-Combo Properties-*/
    [Header("Combo Properties"), SerializeField]
    private float comboHUDHideDelay = 2.0f;

    // The size of the combo 
    private int comboSize = 0;

    // The bonus of the combo
    private int comboBonus = 0;

    // The highest combo size
    private int highestComboSize = 0;

    /*-External References-*/
    MainHUDManager mainHUDManager;
    PaddleController paddleController;
    Ball ballRef;

    // Called before start
    public void Awake()
    {
        // Get the game over audio source
        gameOverAudioSource = GetComponent<AudioSource>();

        // Get the main HUD manager
        mainHUDManager = FindObjectOfType<MainHUDManager>();

        // Get the ball
        ballRef = FindObjectOfType<Ball>();

        // Get the PaddleController
        paddleController = FindObjectOfType<PaddleController>();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Start the game timer
    public void startGameTimer()
    {
        InvokeRepeating("runGameTimer", 1.0f, 1.0f);
    }

    // Stop the game timer
    public void stopGameTimer()
    {
        CancelInvoke("runGameTimer");
    }

    // Run the game timer
    private void runGameTimer()
    {
        // If the number of seconds is greater than 0 then decrement the amount of seconds
        if (timerSeconds > 0)
        {
            timerSeconds--;
            
            // Update the HUD
            mainHUDManager.setTimeTextContent(timerMinutes, timerSeconds);
        }

        // If the number of seconds is 0 then decrement the amount of minutes and set the amount of seconds to 59
        if (timerSeconds == 0 && timerMinutes > 0)
        {
            timerMinutes--;
            timerSeconds = 59;

            // Update the HUD
            mainHUDManager.setTimeTextContent(timerMinutes, timerSeconds);
        }

        // If the number of seconds and minutes is 0 then end the game
        if (timerMinutes == 0 && timerSeconds == 0)
        {
            // Update the HUD
            mainHUDManager.setTimeTextContent(0, timerSeconds);

            // Play a sound
            gameOverAudioSource.Play();

            // Stop the timer
            stopGameTimer();

            // Spawn a particle system at the ball's location
            ParticleManager.playParticleEffect(ballRef.destructionParticle, ballRef.transform.position, ballRef.transform.rotation);

            // End the game
            StartCoroutine(endGame());
        }
    }

    // Pause game
    public void pauseGame()
    {
        isGamePaused = true;

        // Set the time scale to 0
        Time.timeScale = 0;
        
        // If the intro HUD is open hide it
        if (mainHUDManager.introHUDGroup.activeSelf == true)
        {
            mainHUDManager.setHUDGroupVisibility(mainHUDManager.introHUDGroup, false);
        }

        // If the main HUD is open hide it
        if (mainHUDManager.mainHUDGroup.activeSelf == false)
        {
            mainHUDManager.setHUDGroupVisibility(mainHUDManager.mainHUDGroup, false);
        }

        // Show the pause menu
        mainHUDManager.setHUDGroupVisibility(mainHUDManager.pauseHUDGroup, true);
        mainHUDManager.setCurrentScorePauseTextContent(playerScore.ToString());
        
    }

    // Resume game
    public void resumeGame()
    {
        isGamePaused = false;

        // Set the time scale to 1
        Time.timeScale = 1;

        // If the game did not start show the intro HUD and do not let the ball move
        if (didGameStart == false)
        {
            ballRef.setBallStatus(true, true, false, true);
            mainHUDManager.setHUDGroupVisibility(mainHUDManager.introHUDGroup, true);
        }

        // If the game did start show the main HUD
        if (didGameStart == true)
        {
            mainHUDManager.setHUDGroupVisibility(mainHUDManager.mainHUDGroup, true);
        }

        // Set the paddle's destination location to default location
        paddleController.destinationLocation = paddleController.defaultLocation;

        // Hide the pause menu
        mainHUDManager.setHUDGroupVisibility(mainHUDManager.pauseHUDGroup, false);
    }

    // Set game over screen message
    private void setGameOverScreenMessage()
    {
        // If the player reached the target score set the message to be you win
        if (playerScore >= targetScore)
        {
            gameOverScreenMessage = "You Win";
        }

        // If the player did not reach the target score set the message to be you lose
        if (playerScore < targetScore)
        {
            gameOverScreenMessage = "You Lose";
        }
    }

    // End the game
    public IEnumerator endGame()
    {
        // Set game over screen message
        setGameOverScreenMessage();

        // Set the game to be over
        isGameOver = true;

        // Do not allow the player to use the paddle
        paddleController.canPlayerUsePaddle = false;

        // Disable the ball
        ballRef.gameObject.SetActive(false);
        ballRef.setBallStatus(false, true, false, false);

        // Have a delay
        yield return new WaitForSeconds(1.5f);

        // Hide the main game HUD
        mainHUDManager.setHUDGroupVisibility(mainHUDManager.mainHUDGroup, false);

        // Show the game over screen
        mainHUDManager.setGameOverScoreText(playerScore.ToString());
        mainHUDManager.setHighestComboTextContent(highestComboSize.ToString());
        mainHUDManager.setGameOverScreenTitle(gameOverScreenMessage);
        mainHUDManager.setHUDGroupVisibility(mainHUDManager.gameOverHUDGroup, true);
    }

    // Reset current combo
    public void resetCurrentCombo()
    {
        comboSize = 0;
        comboBonus = 0;
    }

    // Set the highest combo size
    private void setHighestComboSize(int size)
    {
        // If the size given is bigger than the current biggest combo size
        if (size > highestComboSize)
        {
            // Set the new highest combo size
            highestComboSize = size;
        }
    }

    // End the current combo
    public IEnumerator endCurrentCombo()
    {
        // If the combo size is greater than 1
        if (comboSize > 1)
        {
            // Calculate the combo bonus
            calculateComboBonus();

            // Set the highest combo size
            setHighestComboSize(comboSize);

            // Display the combo results
            mainHUDManager.setComboTextHUDContent(comboSize, comboBonus, true);

            // Add the bonus to the score
            setPlayerScore(playerScore + comboBonus);

            // Reset current combo
            resetCurrentCombo();

            // Have a delay
            yield return new WaitForSeconds(comboHUDHideDelay);
           
            // Hide the combo results HUD
            mainHUDManager.setComboTextHUDContent(0, 0, false);
        }
    }

    // Calculate the combo bonus
    public void calculateComboBonus()
    {
        comboBonus = comboSize * 10;
    }

    /*--Set properties of the class--*/

    // Set the player score
    public void setPlayerScore(int num)
    {
        playerScore = num;

        // Update the HUD
        mainHUDManager.setMainScoreTextContent(playerScore.ToString());
    }

    // Set the player ball count
    public void setPlayerBallCount(int num)
    {
        playerBallCount = num;

        // Update the HUD
        mainHUDManager.setBallCountContent(playerBallCount.ToString());

        // If the ball count is less than 1 end the game
        if (playerBallCount < 0)
        {
            // Stop the timer
            stopGameTimer();

            // End the game
            StartCoroutine(endGame());
        }
    }

    // Set the size of the combo
    public void setComboSize(int size)
    {
        comboSize = size;
    }

    // Set the bonus of the combo
    public void setComboBonus(int num)
    {
        comboBonus = num;
    }

    /*--Get properties of the class--*/

    // Get the player score
    public int getPlayerScore()
    {
        return playerScore;
    }

    // Get the player ball count
    public int getPlayerBallCount()
    {
        return playerBallCount;
    }

    // Get the combo size
    public int getComboSize()
    {
        return comboSize;
    }

    // Get the combo bonus
    public int getComboBonus()
    {
        return comboBonus;
    }

    // Get the target score for the level
    public int getLevelTargetScore()
    {
        return targetScore;
    }
}
