using UnityEngine;
using System.Collections;

public class PaddleNavPoint : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    /*-Editor GUI Functions-*/

    // Draw a debug box for nav point
    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
        Gizmos.DrawCube(transform.position, transform.lossyScale);
    }

    // Draw a wire frame box when the nav point is selected
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }
}
