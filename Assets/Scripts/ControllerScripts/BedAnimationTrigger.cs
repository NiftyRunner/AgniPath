using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedAnimationTrigger : MonoBehaviour
{
    [SerializeField] Animator crawlAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (crawlAnimator != null)
        {
            //Set crawl animation state here.
            Debug.Log("Crawl Anim Started");
        }
        else
        {
            Debug.Log("Animator reference is null");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (crawlAnimator != null)
        {
            //Pause from here.
            Debug.Log("Crawl Anim Stopped");
        }
    }
}
