using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainHUDManager : MonoBehaviour
{
    /*--Properties of the class--*/

    // Main game HUD objects
    [Header("Main Game HUD Objects"), SerializeField]
    private Text mainScoreText;

    [SerializeField]
    private Text ballCountText;

    // Pause menu HUD objects


    // Game over screen HUD objects

    // HUD groups

    // Use this for initialization
    void Start()
    {
        // Set the main score and ball count text content to 0
        setMainScoreTextContent("0");
        setBallCountContent("0");
    }

    // Update is called once per frame
    void Update()
    {

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

    /*--Pause Menu HUD Functions--*/


    /*--Game Over Screen HUD Functions--*/
}
