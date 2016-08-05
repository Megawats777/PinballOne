using UnityEngine;
using System.Collections;

public class PointBlockNavPoint : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*--Editor Functions--*/

    // Draw a box
    public void OnDrawGizmos()
    {
        GameObject pointBlock = transform.parent.gameObject;

        Gizmos.color = new Color(1.0f, 1.0f, 0.0f, 0.5f);
        Gizmos.DrawCube(transform.position, pointBlock.transform.lossyScale);
    }
}
