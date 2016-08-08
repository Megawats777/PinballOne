using UnityEngine;
using System.Collections;

public class FailLaser : MonoBehaviour
{
    /*--Properties of the class--*/

    // The particle object to play
    [SerializeField]
    private GameObject ballDestroyedParticleEffect;

    /*-External References-*/
    GameManager gameManager;
    Ball ball;

    // Called before start
    public void Awake()
    {
        // Get the GameManager
        gameManager = FindObjectOfType<GameManager>();

        // Get the ball
        ball = FindObjectOfType<Ball>();
    }

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
            // Disable the ball
            ball.setBallStatus(false, true, false);

            // Play a particle effect
            ParticleManager.playParticleEffect(ballDestroyedParticleEffect, transform.position, Quaternion.identity, 5.0f);

            // Reduce the player's ball count
            gameManager.setPlayerBallCount(gameManager.getPlayerBallCount() - 1);

            // If the game is not over
            if (gameManager.isGameOver == false)
            {
                // After a few seconds reset the ball's position to it's starting position
                StartCoroutine(ball.reEnableBall());
            }
        }
    }

}
