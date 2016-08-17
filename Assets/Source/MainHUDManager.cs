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

    [SerializeField]
    private Text comboTitleText;

    [SerializeField]
    private Text comboBonusText;

    [SerializeField]
    private Text targetScoreText;

    // Pause menu HUD objects
    [Header("Pause Menu HUD Objects"), SerializeField]
    private Text currentScorePauseText;

    // Game over screen HUD objects
    [Header("Game Over HUD Objects"), SerializeField]
    private Text gameOverScoreText;

    [SerializeField]
    private Text gameOverScreenTitle;

    [SerializeField]
    private Text highestComboText;

    // HUD groups
    [Header("HUD Groups")]
    public GameObject introHUDGroup;
    public GameObject mainHUDGroup;
    public GameObject gameOverHUDGroup;
    public GameObject pauseHUDGroup;

    // HUD Animators
    [Header("HUD Animators")]
    public Animator gameOverPanelAnimator;
    public Animator pausePanelAnimator;

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
        // Set all but the main HUD groups to be visible
        setHUDGroupVisibility(introHUDGroup, true);
        setHUDGroupVisibility(mainHUDGroup, false);
        setHUDGroupVisibility(gameOverHUDGroup, true);
        setHUDGroupVisibility(pauseHUDGroup, true);

        // Set the main score and ball count text content to 0
        setMainScoreTextContent("0");
        setBallCountContent("3");

        // Hide the combo text HUD objects
        setComboTextHUDContent(0, 0, false);

        // Set the content of the timeText HUD object
        setTimeTextContent(gameManager.timerMinutes, gameManager.timerSeconds);

        // Set the content of the target score text object
        targetScoreText.text = gameManager.getLevelTargetScore().ToString();
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

    // Set the content of combo Text HUD objects
    public void setComboTextHUDContent(int comboSize, int comboBonus, bool visibilityStatus)
    {
        // If the HUD objects can be visible
        if (visibilityStatus == true)
        {
            // Set the content of the combo title object
            comboTitleText.text = comboSize.ToString() + "-Chain Combo";

            // Set the content of the combo bonus object
            comboBonusText.text = "+" + comboBonus.ToString();
        }

        // If the HUD objects cannot be visible then set the content to null
        if (visibilityStatus == false)
        {
            comboBonusText.text = "";
            comboTitleText.text = "";
        }
    }

    /*--Pause Menu HUD Functions--*/

    // Resume game wrapper
    public void resumeGameWrapper()
    {
        gameManager.resumeGame();
    }

    // Set the content of the current score text object
    public void setCurrentScorePauseTextContent(string content)
    {
        currentScorePauseText.text = content;
    }

    /*--Game Over Screen HUD Functions--*/

    // Set the title for the game over screen
    public void setGameOverScreenTitle(string content)
    {
        gameOverScreenTitle.text = content;
    }

    // Set the content of the game over screen text object
    public void setGameOverScoreText(string content)
    {
        gameOverScoreText.text = content;
    }

    // Set the content for the highest combo text object
    public void setHighestComboTextContent(string content)
    {
        highestComboText.text = content;
    }

    /*-Animation Functions-*/

    // Slide the pause panel in
    public void slidePausePanelIn()
    {
        pausePanelAnimator.SetBool("isIdle", false);
        pausePanelAnimator.SetBool("isSlidingOut", false);
        pausePanelAnimator.SetBool("isSlidingIn", true);
    }

    // Slide the pause panel out
    public void slidePausePanelOut()
    {
        pausePanelAnimator.SetBool("isIdle", false);
        pausePanelAnimator.SetBool("isSlidingOut", true);
        pausePanelAnimator.SetBool("isSlidingIn", false);
    }

    // Slide the game over panel in
    public void slideGameOverPanelIn()
    {
        gameOverPanelAnimator.SetBool("isIdle", false);
        gameOverPanelAnimator.SetBool("isSlidingOut", false);
        gameOverPanelAnimator.SetBool("isSlidingIn", true);
    }

    // Slide the game over panel out
    public void slideGameOverPanelOut()
    {
        gameOverPanelAnimator.SetBool("isIdle", false);
        gameOverPanelAnimator.SetBool("isSldingOut", true);
        gameOverPanelAnimator.SetBool("isSldingIn", false);
    }
}
