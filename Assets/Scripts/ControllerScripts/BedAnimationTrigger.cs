using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedAnimationTrigger : MonoBehaviour
{
    [SerializeField] Animator crawlAnimator;
    [SerializeField] PersonRescue personRescue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HandTrigger")
        {
            personRescue.TouchedHands();
        }

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
        if (other.gameObject.tag == "HandTrigger")
        {
            personRescue.ReleasedHands();
        }

        if (crawlAnimator != null)
        {
            //Pause from here.
            Debug.Log("Crawl Anim Stopped");
        }
    }
}
