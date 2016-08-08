using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    /*--Properties of the class--*/

    // The player's score
    private int playerScore;

    // The amount of balls the player has left
    private int playerBallCount = 3;

    // Is the game over
    public bool isGameOver = false;

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
        if (playerBallCount < 1)
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
