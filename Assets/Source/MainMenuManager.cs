﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    [SerializeField]
    private RawImage stageInfoThumbnailImage;

    // Tutorial Screen properties
    [Header("Tutorial Screen Properties"), SerializeField]
    private Animator tutorialBackgroundPanelAnimator;

    // Screen groups
    [Header("Screen Groups"), SerializeField]
    private GameObject welcomeScreenGroup;

    [SerializeField]
    private GameObject levelSelectScreenGroup;

    [SerializeField]
    private GameObject tutorialScreenGroup;

    [SerializeField]
    private GameObject loadingScreenGroup;

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

    // Level thumbnails
    [SerializeField]
    private Texture[] levelThumbnails;

    // Called before start
    public void Awake()
    {
        // Enable all HUD groups
        welcomeScreenGroup.SetActive(true);
        levelSelectScreenGroup.SetActive(true);
        tutorialScreenGroup.SetActive(true);
        loadingScreenGroup.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {

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
        stageInfoThumbnailImage.texture = levelThumbnails[levelIndex];
    }


    /*-Screen transition functions-*/

    // Open the level select screen
    public void openLevelSelectScreen()
    {
        // Slide out the welcome screen elements
        slideOutWelcomeScreen();

        // Slide in the level select screen elements
        slideInLevelSelectScreen();

        // Slide in the stage info panel
        slideInStageInfoPanel();

        // Set the current stage information that is displayed
        setDisplayedStageInfo(0);
    }

    // Open the welcome screen
    public void openWelcomeScreen()
    {
        // Slide out the level select screen elements
        slideOutLevelSelectScreen();

        // Slide out the stage info panel
        slideOutStageInfoPanel();

        // Slide out the tutorial panel
        slideOutTutorialPanel();

        // Slide in the welcome screen elements
        slideInWelcomeScreen();
    }

    // Open the tutorial screen
    public void openTutorialScreen()
    {
        // Slide out the welcome screen
        slideOutWelcomeScreen();

        // Slide in the tutorial panel
        slideInTutorialPanel();
    }

    /*--Slide in UI elements--*/

    // Slide in the welcome screen elements
    public void slideInWelcomeScreen()
    {
        gameTitleAnimator.SetBool("isSlidingOut", false);
        welcomeBackgroundPanelAnimator.SetBool("isSlidingOut", false);
    }

    // Slide in the level select screen elements
    public void slideInLevelSelectScreen()
    {
        levelSelectPanelAnimator.SetBool("isIdle", false);
        levelSelectPanelAnimator.SetBool("isSlidingOut", false);
    }

    // Slide in the stage info panel
    public void slideInStageInfoPanel()
    {
        stageInfoPanelAnimator.SetBool("isIdle", false);
        stageInfoPanelAnimator.SetBool("isSlidingOut", false);
        stageInfoPanelAnimator.SetBool("isSlidingIn", true);
    }

    // Slide in the tutorial background panel
    public void slideInTutorialPanel()
    {
        tutorialBackgroundPanelAnimator.SetBool("isIdle", false);
        tutorialBackgroundPanelAnimator.SetBool("isSlidingOut", false);
        tutorialBackgroundPanelAnimator.SetBool("isSlidingIn", true);
    }

    /*--Slide out UI elements--*/

    // Slide out the welcome screen elements
    public void slideOutWelcomeScreen()
    {
        gameTitleAnimator.SetBool("isSlidingOut", true);
        welcomeBackgroundPanelAnimator.SetBool("isSlidingOut", true);
    }

    // Slide out the level select screen elements
    public void slideOutLevelSelectScreen()
    {
        levelSelectPanelAnimator.SetBool("isSlidingOut", true);
    }

    // Slide out the stage info panel
    public void slideOutStageInfoPanel()
    {
        stageInfoPanelAnimator.SetBool("isSlidingIn", false);
        stageInfoPanelAnimator.SetBool("isSlidingOut", true);
    }

    // Slide out the tutorial background panel
    public void slideOutTutorialPanel()
    {
        tutorialBackgroundPanelAnimator.SetBool("isIdle", false);
        tutorialBackgroundPanelAnimator.SetBool("isSlidingIn", false);
        tutorialBackgroundPanelAnimator.SetBool("isSlidingOut", true);
    }
}
