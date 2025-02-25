using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExtinguishSwitchFire : MonoBehaviour
{
    Animator switchAnimator;
    [SerializeField] List<Light> lights;
    [SerializeField] AudioSource switchSource;
    [SerializeField] LevelManager_Parth levelManager;
 
    private void Start()
    {
        switchAnimator = GetComponent<Animator>();
        foreach (Light light in lights) {
            light.intensity = 9;
        }
    }

    public void TurnSwitchOff()
    {
        levelManager.IncreaseMCBCount();
        switchAnimator.SetTrigger("PlayerInteractedWithSwitch");
        switchSource.Play();
        foreach (Light light in lights) { light.intensity = 0; }
    }
}
