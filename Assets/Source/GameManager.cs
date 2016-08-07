using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    /*--Properties of the class--*/

    // The player's score
    private int playerScore;

    // The amount of balls the player has left
    private int playerBallCount = 3;

    /*-External References-*/
    MainHUDManager mainHUDManager;

    // Called before start
    public void Awake()
    {
        // Get the main HUD manager
        mainHUDManager = FindObjectOfType<MainHUDManager>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
