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

    // Reference to the mesh render
    private Renderer objectMeshRenderer;

    // Reference to the object's collider
    private BoxCollider objectCollider;

    // The target opacity for the object
    private float targetOpacity = 1.0f;

    // The time to re enable the object
    [SerializeField]
    private float reEnableTime;

    // Called before start
    public void Awake()
    {
        // Get the object's collider
        objectCollider = GetComponent<BoxCollider>();

        // Get the mesh renderer
        objectMeshRenderer = GetComponent<Renderer>();
    }

    // Use this for initialization
    void Start()
    {
        // Set the default location
        defaultLocation = transform.position;

        // Set the nav point location
        navPointLocation = pointBlockNavPoint.transform.position;

        // Set the destination location
        destinationLocation = navPointLocation;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the opacity of the object
        setObjectOpactiy();
    }

    // Set the opacity of the object
    private void setObjectOpactiy()
    {
        // Set the new opacity value
        float newOpacity = Mathf.Lerp(objectMeshRenderer.material.color.a, targetOpacity, Time.deltaTime * reEnableTime);
        objectMeshRenderer.material.color = new Color(objectMeshRenderer.material.color.r, objectMeshRenderer.material.color.g, 
                                                      objectMeshRenderer.material.color.b, newOpacity);
    }

    // Set the position lerp value
    private void setPositionLerpValue()
    {

    }

    // Move the object to the its destination
    private void moveObject()
    {

    }

    // When the point block overlaps with an object
    public void OnTriggerEnter(Collider other)
    {
        // If the overlaping object is a ball
        if (other.gameObject.CompareTag("Ball"))
        {
            // Add points

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
