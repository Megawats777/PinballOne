using UnityEngine;
using System.Collections;

public class PointBlock : MonoBehaviour
{
    /*--Properties of the class--*/
   
    // The point value of the block
    [SerializeField]
    private int pointValue = 10;

    // The movement speed of the block
    [SerializeField]
    private float movementSpeed = 0.05f;

    // The default location of the block
    private Vector3 defaultLocation;

    // The location of the nav point
    private Vector3 navPointLocation;

    // The destination location of the point block
    private Vector3 destinationLocation;

    // Point block nav point
    [SerializeField]
    private GameObject pointBlockNavPoint;

    // The position lerp value
    [SerializeField]
    private float positionLerpValue;

    // The particle effect to play
    [SerializeField]
    private GameObject collisionParticleEffect;

    // Can the block move
    private bool canMove = true;

    // Reference to the mesh render
    private Renderer objectMeshRenderer;

    // Reference to the object's collider
    private BoxCollider objectCollider;

    // The target opacity for the object
    private float targetOpacity = 1.0f;

    // The time to re enable the object
    [SerializeField]
    private float reEnableTime;

    // The time until the object changes destination
    [SerializeField]
    private float destinationChangeDelay;

    // Reference to the object's rigidbody
    private Rigidbody blockRigidbody;

    /*-External References-*/
    GameManager gameManager;

    // Called before start
    public void Awake()
    {
        // Get the object's collider
        objectCollider = GetComponent<BoxCollider>();

        // Get the mesh renderer
        objectMeshRenderer = GetComponent<Renderer>();

        // Get the object's rigidbody
        blockRigidbody = GetComponent<Rigidbody>();

        // Get the GameManager
        gameManager = FindObjectOfType<GameManager>();
    }

    // Use this for initialization
    void Start()
    {
        // Set the default location
        defaultLocation = transform.position;

        // Set the nav point location
        navPointLocation = pointBlockNavPoint.transform.position;

        // Set the destination location
        destinationLocation = defaultLocation;

        // Change the destination for the block
        InvokeRepeating("setDestination", 0.0f, destinationChangeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // Set the opacity of the object
        setObjectOpactiy();

        // Move the object to it's destination
        moveObject();
    }

    // Set the opacity of the object
    private void setObjectOpactiy()
    {
        // Set the new opacity value
        float newOpacity = Mathf.Lerp(objectMeshRenderer.material.color.a, targetOpacity, Time.deltaTime * reEnableTime);
        objectMeshRenderer.material.color = new Color(objectMeshRenderer.material.color.r, objectMeshRenderer.material.color.g, 
                                                      objectMeshRenderer.material.color.b, newOpacity);
    }

    // Set the destination for the nav block 
    private void setDestination()
    {
        // If the game is not paused set the destination for the block
        if (gameManager.isGamePaused == false)
        {
            // If the destination is the nav point set the destination as the default location
            if (destinationLocation == navPointLocation)
            {
                destinationLocation = defaultLocation;
            }

            // If the destination is the default location set the destination as the nav point
            else if (destinationLocation == defaultLocation)
            {
                destinationLocation = navPointLocation;
            }
        }
    }

    // Move the object to the its destination
    private void moveObject()
    {
        // If the block can move
        if (canMove == true)
        {
            blockRigidbody.MovePosition(Vector3.Lerp(transform.position, destinationLocation, Time.deltaTime * movementSpeed));
        }
    }

    // Stop movement
    public void stopMovement()
    {
        // Stop changing destinations
        CancelInvoke("setDestination");

        canMove = false;
    }

    // Resume movement
    public void resumeMovement()
    {
        canMove = true;

        // Allow the block to change destinations
        InvokeRepeating("setDestination", destinationChangeDelay, destinationChangeDelay);
    }

    // When the point block overlaps with an object
    public void OnTriggerEnter(Collider other)
    {
        // If the overlaping object is a ball
        if (other.gameObject.CompareTag("Ball"))
        {
            // Add points
            gameManager.setPlayerScore(gameManager.getPlayerScore() + pointValue);

            // Add to the combo size
            gameManager.setComboSize(gameManager.getComboSize() + 1);

            // Play a sound effect

            // Play a particle effect
            ParticleManager.playParticleEffect(collisionParticleEffect, transform.position, Quaternion.identity, 5.0f);

            // Disable the object
            disableObject();
        }

    }

    // Disable the object
    private void disableObject()
    {
        // Disable the colliders and reduce the object's opacity
        objectCollider.enabled = false;
        targetOpacity = 0.0f;

        // Enable the object
        StartCoroutine(enableObject());
    }

    // Enable the object
    private IEnumerator enableObject()
    {
        yield return new WaitForSeconds(reEnableTime);

        // Enable the colliders and increase the object's opacity
        objectCollider.enabled = true;
        targetOpacity = 1.0f;
    }
}
