using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonActions : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
