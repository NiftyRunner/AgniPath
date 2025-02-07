using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveMechanic : MonoBehaviour
{
    Animator stoveAnimator;
    
    void Start()
    {
        stoveAnimator = GetComponent<Animator>();
    }

    public void TurnOffStove()
    {
        stoveAnimator.SetTrigger("PlayerInteractedWithStove");
    }
}
