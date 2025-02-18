using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWindowPart : MonoBehaviour
{
    [SerializeField] GameObject city;
    [SerializeField] List<Animator> windowsToRotate;

    void Start()
    {
        city.SetActive(false);
        
    }

    public void StartWindowSequence()
    {
        city.SetActive(true);
        foreach (var window in windowsToRotate)
        {
            window.SetTrigger("PlayerInteracted");
        }
    }
}
