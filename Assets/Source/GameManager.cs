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

    /*-Timer Properties-*/
    [Header("Timer Properties"), SerializeField]
    public int timerMinutes;

    [SerializeField]
    public int timerSeconds;

    /*-External References-*/
    MainHUDManager mainHUDManager;
    PaddleController paddleController;
    Ball ballRef;

    // Called before start
    public void Awake()
    {
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
        InvokeRepeating("runGameTimer", 0.0f, 1.0f);
    }

    // Run the game timer
    private void runGameTimer()
    {
        // If the number of seconds is greater than 0 then decrement the amount of seconds
        if (timerSeconds > 0)
        {
            timerSeconds--;
            Debug.Log(timerSeconds);
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
            mainHUDManager.setTimeTextContent(timerMinutes, timerSeconds);

            // After half a second end the game
            Invoke("endGame", 0.5f);
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
            ballRef.setBallStatus(true, true, false);
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

    // End the game
    public IEnumerator endGame()
    {
        // Set the game to be over
        isGameOver = true;

        // Do not allow the player to use the paddle
        paddleController.canPlayerUsePaddle = false;

        // Disable the ball
        ballRef.setBallStatus(false, true, false);

        // Hide the main game HUD
        mainHUDManager.setHUDGroupVisibility(mainHUDManager.mainHUDGroup, false);

        // Have a delay
        yield return new WaitForSeconds(1.5f);

        // Show the game over screen
        mainHUDManager.setGameOverScoreText(playerScore.ToString());
        mainHUDManager.setHUDGroupVisibility(mainHUDManager.gameOverHUDGroup, true);
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
            StartCoroutine(endGame());
        }
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
}
