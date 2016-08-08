using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour
{
    /*--Properties of the class--*/

    // The default location of the paddle
    private Vector3 defaultLocation;

    // The location of the paddle nav point
    private Vector3 navPointLocation;

    // The destination location for the paddle
    private Vector3 destinationLocation;

    // The time to blend to the default paddle location
    [SerializeField]
    private float locationBlendTime = 1.0f;

    // Can the player use the paddle
    private bool canPlayerUsePaddle = false;

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
        // If the space button is pressed set the destination location to the nav point location
        if (Input.GetKeyDown(KeyCode.Space) && canPlayerUsePaddle == true)
        {
            destinationLocation = navPointLocation;
        }

        // If the space button was let go set the destination location to the default location
        else if (Input.GetKeyUp(KeyCode.Space) && canPlayerUsePaddle == true)
        {
            destinationLocation = defaultLocation;
        }

        // If the space bar was pressed and the player cannot use the paddle
        if (Input.GetKeyDown(KeyCode.Space) && canPlayerUsePaddle == false)
        {
            // Show the main game HUD
            mainHUDManager.setHUDGroupVisibility(mainHUDManager.introHUDGroup, false);
            mainHUDManager.setHUDGroupVisibility(mainHUDManager.mainHUDGroup, true);

            // Enable the ball
            ballRef.setBallStatus(true, false);

            // Allow the player to use the paddle
            canPlayerUsePaddle = true;
        }
    }

    // Always move to the default location of the paddle
    private void moveToDefaultLocation()
    {
        paddleRigidBody.MovePosition(Vector3.Lerp(transform.position, destinationLocation, Time.deltaTime * locationBlendTime));
    }

    // When a object collides with the paddle
    public void OnCollisionEnter(Collision collision)
    {

    }
}
