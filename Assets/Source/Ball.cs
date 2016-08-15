using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    /*--Properties of the class--*/

    // The starting position of the ball
    private Vector3 startingPosition;

    // Reference to the rigidbody of the ball
    private Rigidbody ballRigidbody;

    // Reference to the mesh renderer of the ball
    private MeshRenderer ballMeshRenderer;

    // Reference to the sphere collider of the ball
    private SphereCollider ballCollider;

    // The ball's destructiontion particle system
    public GameObject destructionParticle;

    // The ball's destruction sound source
    [HideInInspector]
    public AudioSource destructionSoundSource;

    // Called before start
    public void Awake()
    {
        // Get the ball's rigidbody
        ballRigidbody = GetComponent<Rigidbody>();

        // Get the ball's destruction sound source
        destructionSoundSource = GetComponent<AudioSource>();

        // Get the ball's mesh renderer
        ballMeshRenderer = GetComponent<MeshRenderer>();

        // Get the ball's collider
        ballCollider = GetComponent<SphereCollider>();
    }

    // Use this for initialization
    void Start()
    {
        // Set the starting position of the ball
        startingPosition = transform.position;

        // Disable the ball
        setBallStatus(true, true, false, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set the ball status
    public void setBallStatus(bool meshVisibility, bool kinematicStatus, bool gravityStatus, bool colliderStatus)
    {
        // Set the ball to be kinematic
        ballRigidbody.isKinematic = kinematicStatus;

        // Disable or enable the ball's mesh renderer
        ballMeshRenderer.enabled = meshVisibility;

        // Set if the collider is active or inactive
        ballCollider.enabled = colliderStatus;

        // Set if the ball uses gravity
        ballRigidbody.useGravity = gravityStatus;
    }

    // Reposition the ball
    public IEnumerator reEnableBall()
    {
        yield return new WaitForSeconds(2.0f);

        // Set the location of the ball, renable it's mesh renderer, and make it no longer kinematic
        ballRigidbody.MovePosition(startingPosition);

        yield return new WaitForSeconds(1.05f);

        ballCollider.enabled = true;
        ballRigidbody.useGravity = true;
        ballRigidbody.isKinematic = false;
        ballMeshRenderer.enabled = true;
    }
}
