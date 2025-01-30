using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExtinguishSwitchFire : MonoBehaviour
{
    Animator switchAnimator;

    private void Start()
    {
        switchAnimator = GetComponent<Animator>();
    }

    public void TurnSwitchOff()
    {
        switchAnimator.SetTrigger("PlayerInteractedWithSwitch");
    }
}
