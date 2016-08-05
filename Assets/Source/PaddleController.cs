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

    // Ball bounce force
    [SerializeField]
    private float ballBounceForce = 200.0f;

    // Reference to the paddle nav point
    [SerializeField]
    private PaddleNavPoint paddleNavPoint;

    private Rigidbody paddleRigidBody;

    // Called before start
    public void Awake()
    {
        paddleRigidBody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        // Set the default location of the paddle
        defaultLocation = transform.position;

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

    // Control paddle movement
    private void controlPaddleMovement()
    {
        // If the space button is pressed set the destination location to the nav point location
        if (Input.GetKeyDown(KeyCode.Space))
        {
            destinationLocation = navPointLocation;
        }

        // If the space button was let go set the destination location to the default location
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            destinationLocation = defaultLocation;
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
        // If the ball collides with the paddle bounce the ball up
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            if (ballRigidBody)
            {
                // If the location of the paddle is not the same as the nav point location then bounce the ball
                if (transform.position != navPointLocation)
                {
                    //ballRigidBody.AddForce(new Vector3(0.0f, ballBounceForce, 0.0f));
                }
            }
        }
    }
}
