using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWindowPart : MonoBehaviour
{
    [SerializeField] GameObject city;
    [SerializeField] List<SmoothRotation> windowsToRotate;

    void Start()
    {
        city.SetActive(false);
        foreach (var window in windowsToRotate)
        {
            window.rotStart = false;
        }
    }

    public void StartWindowSequence()
    {
        city.SetActive(true);
        foreach (var window in windowsToRotate)
        {
            window.rotStart = true;
        }
    }
}
