using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonActions : MonoBehaviour
{

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

    // Open a level
    public void openLevel(string levelName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(levelName);
    }

    // Quit the application
    public void quitApplication()
    {
        Application.Quit();
    }
}
