using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonActions : MonoBehaviour
{
    // Reference to the button's audio source component
    private AudioSource clickedAudioSource;

    // Reference to the loading particle component
    private GameObject loadingParticle;

    /*-External References-*/
    GameManager gameManager;
    MainHUDManager mainHUDManager;
    PaddleController paddleRef;
    Ball ballRef;
    PointBlock[] pointBlocks;
    LoadingScreen loadingScreenRef;

    // Called before start
    public void Awake()
    {
        // Get the GameManager
        gameManager = FindObjectOfType<GameManager>();

        // Get the loading screen
        loadingScreenRef = FindObjectOfType<LoadingScreen>();

        // Get the button's audio source component
        clickedAudioSource = GetComponent<AudioSource>();

        // Get the main HUD manager
        mainHUDManager = FindObjectOfType<MainHUDManager>();

        // Get the player's paddle
        paddleRef = FindObjectOfType<PaddleController>();

        // Get the ball
        ballRef = FindObjectOfType<Ball>();

        // Get the point blocks in the level
        pointBlocks = FindObjectsOfType<PointBlock>();

        // Get the loading particle gameobject
        loadingParticle = GameObject.FindGameObjectWithTag("LoadingParticle");
    }

    // Use this for initialization
    void Start()
    {
        // If a loading particle system exists
        if (loadingParticle)
        {
            // Disable the loading particle
            loadingParticle.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Pause Function wrapper
    public void pauseWrapper()
    {
        gameManager.pauseGame();
    }

    /*--Open Level Functions--*/

    // Open a level wrapper
    public void openLevelWrapper(string levelName)
    {
        Time.timeScale = 1.0f;

        // If a loading particle exists enable it
        if (loadingParticle)
        {
            loadingParticle.SetActive(true);
        }

        // Show the loading screen
        loadingScreenRef.slideLoadingPanelIn();

        // Open a level with a delay
        StartCoroutine(openLevel(levelName));
    }

    // Open a level with a delay
    private IEnumerator openLevel(string levelName)
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadSceneAsync(levelName);
    }

    /*--Reload Level Functions--*/

    // Reload the current level wrapper
    public void reloadCurrentLevelWrapper()
    {
        Time.timeScale = 1.0f;

        // Prevent the player from using their paddle
        paddleRef.canPlayerUsePaddle = false;

        // Stop the game timer
        gameManager.stopGameTimer();

        // Disable the ball
        ballRef.setBallStatus(true, true, false, false);

        // Hide the intro and main HUD group
        mainHUDManager.introHUDGroup.SetActive(false);
        mainHUDManager.mainHUDGroup.SetActive(false);

        // Enable the loading particle
        loadingParticle.SetActive(true);

        // Show the loading screen
        loadingScreenRef.slideLoadingPanelIn();

        

        // Reload the current level with a delay
        StartCoroutine(reloadCurrentLevel(SceneManager.GetActiveScene().name));
    }

    // Reload level for the pause screen wrapper
    public void reloadCurrentLevelWrapperPauseScreen()
    {
        Time.timeScale = 1.0f;

        // Prevent the player from using their paddle
        paddleRef.canPlayerUsePaddle = false;

        // Stop the game timer
        gameManager.stopGameTimer();

        // Disable the ball
        ballRef.setBallStatus(true, true, false, false);

        // Hide the intro and main HUD group
        mainHUDManager.introHUDGroup.SetActive(false);
        mainHUDManager.mainHUDGroup.SetActive(false);

        // Enable the loading particle
        loadingParticle.SetActive(true);

        // Show the loading screen
        loadingScreenRef.slideLoadingPanelIn();

        // Stop the point blocks from moving
        foreach (PointBlock pb in pointBlocks)
        {
            pb.stopMovement();
        }

        // Reload the current level with a delay
        StartCoroutine(reloadCurrentLevel(SceneManager.GetActiveScene().name));
    }

    // Reload the current level with a delay
    public IEnumerator reloadCurrentLevel(string levelName)
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadSceneAsync(levelName);
    }

    // Quit the application
    public void quitApplication()
    {
        Application.Quit();
    }

    // Play a sound when clicked
    public void playClickedSound()
    {
        // Play a sound
        clickedAudioSource.Play();
    }
}
