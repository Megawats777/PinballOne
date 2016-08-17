using UnityEngine;
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

    // Screen groups
    [Header("Screen Groups"), SerializeField]
    private GameObject welcomeScreenGroup;

    [SerializeField]
    private GameObject levelSelectScreenGroup;

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
