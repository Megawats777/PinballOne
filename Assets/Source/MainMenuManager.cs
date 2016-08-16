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

    // Use this for initialization
    void Start()
    {

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
    }

    // Open the welcome screen
    public void openWelcomeScreen()
    {
        // Slide out the level select screen elements

        // Slide in the welcome screen elements
        gameTitleAnimator.SetBool("isSlidingOut", false);
        welcomeBackgroundPanelAnimator.SetBool("isSlidingOut", false);
    }
}
