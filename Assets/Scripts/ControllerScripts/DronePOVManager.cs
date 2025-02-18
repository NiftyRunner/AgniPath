using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronePOVManager : MonoBehaviour
{
    bool isSwitched;

    //[Header("Camera Settings")]
    //[SerializeField] Transform droneCamera;
    //[SerializeField] Vector3 fpvPosition;
    //[SerializeField] Quaternion fpvRotation;

    [Header("Drone Position")]
    [SerializeField] Vector3 fpvAreaPosition;

    [Header("General Settings")]
    [SerializeField] int extinguishableFireCount;

    FadeManager fadeManager;
    DroneSimMover droneSimMover;

    private void Start()
    {
        fadeManager = FindAnyObjectByType<FadeManager>();
        droneSimMover = FindAnyObjectByType<DroneSimMover>();
        isSwitched = false;
    }

    private void Update()
    {
        if (ExtinguishFire.fireCount >= extinguishableFireCount && !isSwitched)
        {
            StartCoroutine(fadeManager.FadeInOutEffect());
            SwitchToFPV();
            isSwitched=true;
        }
    }

    public void SwitchToFPV()
    {
        transform.position = fpvAreaPosition;
        droneSimMover.SwitchPOV();
    }
}
