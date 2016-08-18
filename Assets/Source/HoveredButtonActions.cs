using UnityEngine;
using System.Collections;

public class HoveredButtonActions : MonoBehaviour
{

    /*--Properties of the class--*/

    // Reference to the button's audio source component
    private AudioSource buttonAudioSource;

    // Called before start
    public void Awake()
    {
        // Get the button's audio source component
        buttonAudioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Play a sound
    public void playHoveredSound()
    {
        buttonAudioSource.Play();
    }
}
