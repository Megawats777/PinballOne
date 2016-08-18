using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{
    /*--Properties of the class--*/


    // Welcome screen properties
    [Header("Welcome Screen Properties"), SerializeField]
    private Animator gameTitleAnimator;

    [SerializeField]
    private Animator welcomeBackgroundPanelAnimator;

    // Level select screen properties
    [Header("Level Select Screen Properties"), SerializeField]
    private Animator levelSelectPanelAnimator;

    [SerializeField]
    private Animator stageInfoPanelAnimator;

    [SerializeField]
    private Text stageInfoNameText;

    [SerializeField]
    private Text stageInfoTargetScoreText;

    [SerializeField]
    private Text stageInfoTimeLimitText;

    // Screen groups
    [Header("Screen Groups"), SerializeField]
    private GameObject welcomeScreenGroup;

    [SerializeField]
    private GameObject levelSelectScreenGroup;

    /*-Level Display Properties-*/

    // Level Names
    [Header("Level Display Properties"), SerializeField]
    private string[] levelNames;

    // Level target scores
    [SerializeField]
    private string[] levelTargetScores;

    // Level time limits
    [SerializeField]
    private string[] levelTimeLimits;

    // Use this for initialization
    void Start()
    {
        // Enable all HUD groups
        welcomeScreenGroup.SetActive(true);
        levelSelectScreenGroup.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set the current stage information that is displayed
    public void setDisplayedStageInfo(int levelIndex)
    {
        stageInfoNameText.text = levelNames[levelIndex];
        stageInfoTargetScoreText.text = levelTargetScores[levelIndex];
        stageInfoTimeLimitText.text = levelTimeLimits[levelIndex];
    }


    /*-Screen transition functions-*/

    // Open the level select screen
    public void openLevelSelectScreen()
    {
        // Slide out the welcome screen elements
        gameTitleAnimator.SetBool("isSlidingOut", true);
        welcomeBackgroundPanelAnimator.SetBool("isSlidingOut", true);

        // Slide in the level select screen elements
        levelSelectPanelAnimator.SetBool("isIdle", false);
        levelSelectPanelAnimator.SetBool("isSlidingOut", false);

        // Slide in the stage info panel
        stageInfoPanelAnimator.SetBool("isIdle", false);
        stageInfoPanelAnimator.SetBool("isSlidingOut", false);
        stageInfoPanelAnimator.SetBool("isSlidingIn", true);

        // Set the current stage information that is displayed
        setDisplayedStageInfo(0);
    }

    // Open the welcome screen
    public void openWelcomeScreen()
    {
        // Slide out the level select screen elements
        levelSelectPanelAnimator.SetBool("isSlidingOut", true);

        // Slide out the stage info panel
        stageInfoPanelAnimator.SetBool("isSlidingIn", false);
        stageInfoPanelAnimator.SetBool("isSlidingOut", true);

        // Slide in the welcome screen elements
        gameTitleAnimator.SetBool("isSlidingOut", false);
        welcomeBackgroundPanelAnimator.SetBool("isSlidingOut", false);
    }
}
