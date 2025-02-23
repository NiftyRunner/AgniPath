using NiFTY;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class DroneSimMover : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform droneBody;
    [SerializeField] DroneXRSimControls droneControls;
    [SerializeField] ParticleSystem waterParticlesTPP;
    [SerializeField] ParticleSystem waterParticlesFPP;
    [SerializeField] List<DroneEngine> engines;
    [SerializeField] GameObject tppOrigin;
    [SerializeField] GameObject fppOrigin;


    [Header("Properties")]
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float heightSpeed;
    [SerializeField] float tiltAmount;
    [SerializeField] float rotationSpeed;

    [Header("Bools")]
    public bool isTPP;
    public bool isFPP;

    Rigidbody rb;

    Vector2 moveDirection;
    float turnDirection;
    float heightDirection;
    float waterEnable;
    float switchTriggered;
    bool switchedCurrently;
    FadeManager fadeManager;

    InputAction move;
    InputAction turn;
    InputAction height;
    InputAction fireWater;
    InputAction switchPOV;

    private void Awake()
    {
        fadeManager = FindAnyObjectByType<FadeManager>();
        rb = GetComponent<Rigidbody>();
        droneControls = new DroneXRSimControls();
        switchedCurrently = false;
    }

    private void OnEnable()
    {
        move = droneControls.DroneControls.Move;
        turn = droneControls.DroneControls.Turn;
        height = droneControls.DroneControls.Height;
        fireWater = droneControls.DroneControls.Fire;
        switchPOV = droneControls.DroneControls.SwitchPOV;

        move.Enable();
        turn.Enable();
        height.Enable();
        fireWater.Enable();
        switchPOV.Enable();

        if (isTPP)
        {
            tppOrigin.SetActive(true);
            fppOrigin.SetActive(false);
        }
        else if (isFPP)
        {
            tppOrigin.SetActive(false);
            fppOrigin.SetActive(true);
        }
        else
        {
            Debug.Log("No bool selected");
        }
    }

    private void OnDisable()
    {
        move.Disable();
        turn.Disable();
        height.Disable();
        fireWater.Disable();
        switchPOV.Disable();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        if (IsXRDeviceSimulated())
        {
            turnDirection = turn.ReadValue<float>(); // Read as float for XR simulation
        }
        else
        {
            turnDirection = turn.ReadValue<Vector2>().x; // Read as Vector2 and extract x-axis for other devices
        }
        heightDirection = height.ReadValue<float>();
        waterEnable = fireWater.ReadValue<float>();
        switchTriggered = switchPOV.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        DroneMove();
        DroneTurn();
        DroneHeight();
        DroneWaterControl();
        EngineRotator();
        TriggerSwitch();
    }

    private void TriggerSwitch()
    {
        if (switchTriggered != 0f && !switchedCurrently)
        {
            switchedCurrently = true; // Prevent rapid switching
            StartCoroutine(fadeManager.FadeInOutEffect());

            if (isTPP)
            {
                Invoke(nameof(SwitchToFPP), 0.2f);
            }
            else if (isFPP)
            {
                Invoke(nameof(SwitchToTPP), 0.2f);
            }

            Invoke(nameof(ResetSwitch), 1f);
        }
    }

    private void ResetSwitch()
    {
        switchedCurrently = false; // Allow switching again
    }


    private void SwitchToTPP()
    {
        isTPP = true;
        isFPP = false;
        switchedCurrently = true;
        tppOrigin.SetActive(true);
        fppOrigin.SetActive(false);
    }

    private void SwitchToFPP()
    {
        isTPP = false;
        isFPP = true;
        switchedCurrently = true;
        tppOrigin.SetActive(false);
        fppOrigin.SetActive(true);
    }

    private void EngineRotator()
    {
        foreach (var engine in engines)
        {
            engine.HandlePropellers();
        }
    }

    private void DroneWaterControl()
    {
        if (waterEnable != 0f && isTPP)
        {
            waterParticlesTPP.Play();
        }
        else if(waterEnable != 0f && isFPP)
        {
            waterParticlesFPP.Play();
        }
        else
        {
            waterParticlesTPP.Stop();
            waterParticlesFPP.Stop();
        }
    }

    private void DroneMove()
    {
        Vector3 localMovement = new Vector3(moveDirection.x, 0, moveDirection.y);
        Vector3 worldMovement = transform.TransformDirection(localMovement);

        // Set the Rigidbody's velocity based on the transformed direction
        rb.velocity = new Vector3(worldMovement.x * moveSpeed, rb.velocity.y, worldMovement.z * moveSpeed);
        if (localMovement.sqrMagnitude > 0.01f) // Threshold to avoid tiny inputs
        {
            // Tilt the drone based on X and Z movement
            float tiltX = localMovement.z * tiltAmount; // Tilt forward/backward based on Z movement
            float tiltZ = -localMovement.x * tiltAmount;  // Tilt sideways based on X movement

            Quaternion targetRotation = Quaternion.Euler(tiltX, 0, tiltZ);
            droneBody.localRotation = Quaternion.Lerp(droneBody.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Smoothly return to default rotation when idle
            droneBody.localRotation = Quaternion.Lerp(droneBody.localRotation, Quaternion.identity, rotationSpeed * Time.deltaTime);
        }
    }

    private void DroneTurn()
    {
        transform.Rotate(0, turnDirection * turnSpeed * Time.fixedDeltaTime, 0);
    }

    private void DroneHeight()
    {
        rb.velocity = new Vector3(rb.velocity.x, heightDirection * heightSpeed, rb.velocity.z);
    }

    private bool IsXRDeviceSimulated()
    {
        // Check all active input devices
        var devices = InputSystem.devices;

        foreach (var device in devices)
        {
            // If an XRSimulatedController is detected, return true
            if (device is XRSimulatedController)
            {
                return true;
            }
        }

        // No XRSimulatedController found, return false
        return false;
    }

    void ChangeSwitchSetting()
    {
        switchedCurrently = !switchedCurrently;
    }

    //public void ChangePOV()
    //{
    //    StartCoroutine(fadeManager.FadeInOutEffect());
    //    tppOrigin.SetActive(!tppOrigin);
    //    isTPP = !tppOrigin;
    //    fppOrigin.SetActive(tppOrigin);
    //    isFPP = tppOrigin;
    //}
}
