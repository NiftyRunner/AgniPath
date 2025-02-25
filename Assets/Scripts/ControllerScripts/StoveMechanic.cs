using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveMechanic : MonoBehaviour
{
    Animator stoveAnimator;
    AudioSource stoveAudio;
    [SerializeField] AudioSource parentStoveSource;
    [SerializeField] LevelManager_Parth levelManager;
    
    void Start()
    {
        stoveAudio = GetComponent<AudioSource>();
        stoveAnimator = GetComponent<Animator>();
    }

    public void TurnOffStove()
    {
        levelManager.IncreaseStoveCount();
        stoveAnimator.SetTrigger("PlayerInteractedWithStove");
        if (parentStoveSource != null && parentStoveSource.volume == 1f)
        {
            parentStoveSource.volume = 0.5f;
        }
        else if(parentStoveSource != null && parentStoveSource.volume == 0.5f)
        {
            parentStoveSource.volume = 0f;
        }
        
        stoveAudio.Play();
    }
}
