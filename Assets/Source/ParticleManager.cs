using UnityEngine;
using System.Collections;

public class ParticleManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Play a particle effect
    public static void playParticleEffect(GameObject particleSystem, Vector3 spawnLocation, Quaternion spawnRotation)
    {
        if (particleSystem)
        {
            GameObject particleObject = (GameObject) Instantiate(particleSystem, spawnLocation, spawnRotation);
            Destroy(particleObject, 20.0f);
        }
    }
}
