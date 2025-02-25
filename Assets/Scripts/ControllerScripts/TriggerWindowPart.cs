using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWindowPart : MonoBehaviour
{
    [SerializeField] GameObject city;
    [SerializeField] List<Animator> windowsToRotate;
    [SerializeField] LevelManager_Parth levelManager;
    [SerializeField] Canvas finalCanavs;

    void Start()
    {
        finalCanavs.enabled = false;
        city.SetActive(false);
    }

    public void StartWindowSequence()
    {
        levelManager.isLevelRunning = false;

        finalCanavs.enabled = true;
        city.SetActive(true);
        foreach (var window in windowsToRotate)
        {
            window.SetTrigger("PlayerInteracted");
        }
    }
}
