using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainHUDManager : MonoBehaviour
{
    /*--Properties of the class--*/

    // Intro HUD objects
    [Header("Intro HUD Objects"), SerializeField]
    private Text startText;

    // Main game HUD objects
    [Header("Main Game HUD Objects"), SerializeField]
    private Text mainScoreText;

    [SerializeField]
    private Text ballCountText;

    [SerializeField]
    private Text timeText;

    // Pause menu HUD objects


    // Game over screen HUD objects
    [Header("Game Over HUD Objects"), SerializeField]
    private Text gameOverScoreText;

    // HUD groups
    [Header("HUD Groups")]
    public GameObject introHUDGroup;
    public GameObject mainHUDGroup;
    public GameObject gameOverHUDGroup;
    public GameObject pauseHUDGroup;

    /*-External References-*/
    GameManager gameManager;

    // Called before start
    public void Awake()
    {
        // Get the GameManager
        gameManager = FindObjectOfType<GameManager>();
    }

    // Use this for initialization
    void Start()
    {
        // Set intro group to be visible first
        setHUDGroupVisibility(introHUDGroup, true);

        // Hide other pause groups
        setHUDGroupVisibility(mainHUDGroup, false);
        setHUDGroupVisibility(gameOverHUDGroup, false);
        setHUDGroupVisibility(pauseHUDGroup, false);

        // Set the main score and ball count text content to 0
        setMainScoreTextContent("0");
        setBallCountContent("3");

        // Set the content of the timeText HUD object
        setTimeTextContent(gameManager.timerMinutes, gameManager.timerSeconds);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set the visibility of HUD groups
    public void setHUDGroupVisibility(GameObject group, bool status)
    {
        group.SetActive(status);
    }

    /*--Main Game HUD Functions--*/

    // Set the content of the main score text object
    public void setMainScoreTextContent(string content)
    {
        mainScoreText.text = content;
    }

    // Set the content of the ball count text object
    public void setBallCountContent(string content)
    {
        ballCountText.text = content;
    }

    // Set the content of the timeText HUD object
    public void setTimeTextContent(int minute, int seconds)
    {
        // If the seconds given is greater than 9 then show the seconds whole number
        if (seconds > 9)
        {
            timeText.text = minute.ToString() + ":" + seconds.ToString();
        }

        // If the seconds given is less than 10 then add a "0" character before showing the seconds number
        if (seconds < 10)
        {
            timeText.text = minute.ToString() + ":0" + seconds.ToString();
        }
    }

    /*--Pause Menu HUD Functions--*/


    /*--Game Over Screen HUD Functions--*/

    // Set the content of the game over screen text object
    public void setGameOverScoreText(string content)
    {
        gameOverScoreText.text = content;
    }
}
