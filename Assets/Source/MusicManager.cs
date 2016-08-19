using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    /*--Properties of the class--*/

    // Reference to the audio source component
    private AudioSource musicAudioSource;

    // Music for the stages
    [SerializeField]
    private AudioClip[] stageMusic;

    // The selected music index
    private int musicSelectionIndex;

    // Called before start
    public void Awake()
    {
        // Get the audio source component
        musicAudioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        // Set a new song to play
        setSongToPlay();

        // Start invoke function to repeat selecting a new song just after the last song was finished
        InvokeRepeating("setSongToPlay", stageMusic[musicSelectionIndex].length, stageMusic[musicSelectionIndex].length + 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set a new song to play
    private void setSongToPlay()
    {
        // Set the music selection index
        musicSelectionIndex = Random.Range(0, stageMusic.Length);

        // If the selected clip exists
        if (stageMusic[musicSelectionIndex])
        {
            // Set the audio clip to be played
            musicAudioSource.clip = stageMusic[musicSelectionIndex];

            // Play the music
            musicAudioSource.Play();
        }
    }
}
