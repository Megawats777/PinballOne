using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour
{
    /*--Properties of the class--*/

    // The default location of the paddle
    [HideInInspector]
    public Vector3 defaultLocation;

    // The location of the paddle nav point
    [HideInInspector]
    public Vector3 navPointLocation;

    // The destination location for the paddle
    [HideInInspector]
    public Vector3 destinationLocation;

    // The time to blend to the default paddle location
    [SerializeField]
    private float locationBlendTime = 1.0f;

    // Can the player use the paddle
    public bool canPlayerUsePaddle = false;

    // Reference to the paddle nav point
    [SerializeField]
    private PaddleNavPoint paddleNavPoint;

    // The paddle's rigidbody
    private Rigidbody paddleRigidBody;

    /*-External References-*/
    GameManager gameManager;
    MainHUDManager mainHUDManager;
    Ball ballRef;

    // Called before start
    public void Awake()
    {
        // Get the paddle's rigidbody
        paddleRigidBody = GetComponent<Rigidbody>();

        // Get the Ball
        ballRef = FindObjectOfType<Ball>();

        // Get the GameManager
        gameManager = FindObjectOfType<GameManager>();

        // Get the MainHUDManager
        mainHUDManager = FindObjectOfType<MainHUDManager>();
    }

    // Use this for initialization
    void Start()
    {
        // Set the default location of the paddle
        defaultLocation = transform.position;

        // Set the destination location as the default location
        destinationLocation = defaultLocation;

        // Get the nav point location
        navPointLocation = paddleNavPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Control paddle movement
        controlPaddleMovement();

        // Always move to the default location of the paddle
        moveToDefaultLocation();
    }

    // Physics Update
    public void FixedUpdate()
    {
        
    }

    // Control paddle movement
    private void controlPaddleMovement()
    {
        // If the UsePaddle button is pressed, the player can use the paddle, and the game is not paused set the destination location to the nav point location
        if (Input.GetButtonDown("UsePaddle") && canPlayerUsePaddle == true && gameManager.isGamePaused == false)
        {
            destinationLocation = navPointLocation;
        }

        // If the UsePaddle button was let go, the player can use the paddle, and the game is not paused set the destination location to the default location
        else if (Input.GetButtonUp("UsePaddle") && canPlayerUsePaddle == true && gameManager.isGamePaused == false)
        {
            destinationLocation = defaultLocation;
        }

        // If the UsePaddle button was pressed, the game is not over, the game is not paused and the player cannot use the paddle then start the game
        if (Input.GetButtonDown("UsePaddle") && gameManager.isGameOver == false && gameManager.isGamePaused == false && canPlayerUsePaddle == false)
        {
            gameManager.didGameStart = true;

            // Show the main game HUD
            mainHUDManager.setHUDGroupVisibility(mainHUDManager.introHUDGroup, false);
            mainHUDManager.setHUDGroupVisibility(mainHUDManager.mainHUDGroup, true);

            // Enable the ball
            ballRef.setBallStatus(true, false, true, true);

            // Allow the player to use the paddle
            canPlayerUsePaddle = true;

            // Start the game timer
            gameManager.startGameTimer();
        }
    }

    // Always move to the default location of the paddle
    private void moveToDefaultLocation()
    {
        paddleRigidBody.MovePosition(Vector3.Lerp(transform.position, destinationLocation, Time.deltaTime * locationBlendTime));
    }
}
