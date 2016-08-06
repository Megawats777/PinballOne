using UnityEngine;
using System.Collections;

public class FailLaser : MonoBehaviour
{
    /*--Properties of the class--*/

    // The particle object to play
    [SerializeField]
    private GameObject ballDestroyedParticleEffect;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // When the laser is overlaped by an object
    public void OnTriggerEnter(Collider other)
    {
        // If the laser is overlaped by the ball
        if (other.gameObject.CompareTag("Ball"))
        {
            // Destroy the ball
            Destroy(other.gameObject);

            // Play a particle effect
            ParticleManager.playParticleEffect(ballDestroyedParticleEffect, transform.position, Quaternion.identity, 5.0f);
            
            // Show the game over screen after a few seconds
        }
    }

}
