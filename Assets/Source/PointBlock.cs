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
        // Set the position lerp value
        setPositionLerpValue();

        // Move the object to the its destination
        moveObject();
    }

    // Set the position lerp value
    private void setPositionLerpValue()
    {
        // If the position lerp value is at 0 increase the lerp value
        if (transform.position == defaultLocation)
        {
            positionLerpValue += 0.01f * movementSpeed;
            destinationLocation = navPointLocation;
        }

        // If the position lerp value is at 1 decrease the lerp value
        else if (transform.position == navPointLocation)
        {
            positionLerpValue -= 0.01f * movementSpeed;
            destinationLocation = defaultLocation;
        }
    }

    // Move the object to the its destination
    private void moveObject()
    {
        transform.position = Vector3.Lerp(transform.position, destinationLocation, positionLerpValue);
    }
}
