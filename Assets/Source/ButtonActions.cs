using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonActions : MonoBehaviour
{

    /*-External References-*/
    GameManager gameManager;
    MainHUDManager mainHUDManager;

    // Called before start
    public void Awake()
    {
        // Get the GameManager
        gameManager = FindObjectOfType<GameManager>();

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

    // Pause Function wrapper
    public void pauseWrapper()
    {
        gameManager.pauseGame();
        mainHUDManager.setHUDGroupVisibility(mainHUDManager.mainHUDGroup, false);
    }

    // Open a level
    public void openLevel(string levelName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(levelName);
    }

    // Reload the current level
    public void reloadCurrentLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Quit the application
    public void quitApplication()
    {
        Application.Quit();
    }
}
