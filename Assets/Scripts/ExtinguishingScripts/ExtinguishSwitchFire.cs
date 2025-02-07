using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExtinguishSwitchFire : MonoBehaviour
{
    Animator switchAnimator;
    [SerializeField] List<Light> lights;

    private void Start()
    {
        switchAnimator = GetComponent<Animator>();
        foreach (Light light in lights) {
            light.intensity = 9;
        }
    }

    public void TurnSwitchOff()
    {
        switchAnimator.SetTrigger("PlayerInteractedWithSwitch");
        foreach (Light light in lights) { light.intensity = 0; }
    }
}
