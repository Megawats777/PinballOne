using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    /*--Properties of the class--*/

    // Reference to the animator component
    [SerializeField]
    private Animator loadingScreenAnimator;

    // Called before start
    public void Awake()
    {
        // Get the animator component
        loadingScreenAnimator = GetComponentInChildren<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*--Animation functions--*/

    // Slide the loading panel in
    public void slideLoadingPanelIn()
    {
        loadingScreenAnimator.SetBool("isIdle", false);
        loadingScreenAnimator.SetBool("isSlidingIn", true);
    }
}
