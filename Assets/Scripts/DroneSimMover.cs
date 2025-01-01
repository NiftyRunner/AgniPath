using NiFTY;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneSimMover : MonoBehaviour
{
    [SerializeField] DroneXRSimControls droneControls;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float heightSpeed;
    [SerializeField] ParticleSystem waterParticles;
    [SerializeField] List<DroneEngine> engines;

    Rigidbody rb;

    Vector2 moveDirection;
    float turnDirection;
    float heightDirection;
    float waterEnable;

    InputAction move;
    InputAction turn;
    InputAction height;
    InputAction fireWater;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        droneControls = new DroneXRSimControls();
    }

    private void OnEnable()
    {
        move = droneControls.DroneControls.Move;
        turn = droneControls.DroneControls.Turn;
        height = droneControls.DroneControls.Height;
        fireWater = droneControls.DroneControls.Fire;

        move.Enable();
        turn.Enable();
        height.Enable();
        fireWater.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        turn.Disable();
        height.Disable();
        fireWater.Disable();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        turnDirection = turn.ReadValue<float>();
        heightDirection = height.ReadValue<float>();
        waterEnable = fireWater.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        DroneMove();
        DroneTurn();
        DroneHeight();
        DroneWaterControl();
        EngineRotator();
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
        if (waterEnable != 0f)
        {
            waterParticles.Play();
        }
        else
        {
            waterParticles.Stop();
        }
    }

    private void DroneMove()
    {
        Vector3 localMovement = new Vector3(moveDirection.x, 0, moveDirection.y);
        Vector3 worldMovement = transform.TransformDirection(localMovement);

        // Set the Rigidbody's velocity based on the transformed direction
        rb.velocity = new Vector3(worldMovement.x * moveSpeed, rb.velocity.y, worldMovement.z * moveSpeed);
    }

    private void DroneTurn()
    {
        transform.Rotate(0, turnDirection * turnSpeed * Time.fixedDeltaTime, 0);
    }

    private void DroneHeight()
    {
        rb.velocity = new Vector3(rb.velocity.x, heightDirection * heightSpeed, rb.velocity.z);
    }
}
