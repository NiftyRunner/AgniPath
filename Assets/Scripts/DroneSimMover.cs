using UnityEngine;
using UnityEngine.InputSystem;

public class DroneSimMover : MonoBehaviour
{
    [SerializeField] DroneXRSimControls droneControls;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float heightSpeed;

    Rigidbody rb;

    Vector2 moveDirection;
    float turnDirection;
    float heightDirection;

    InputAction move;
    InputAction turn;
    InputAction height;

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

        move.Enable();
        turn.Enable();
        height.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        turn.Disable();
        height.Disable();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        turnDirection = turn.ReadValue<float>();
        heightDirection = height.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        DroneMove();
        DroneTurn();
        DroneHeight();
    }

    private void DroneMove()
    {
        rb.velocity = new Vector3(-moveDirection.x * moveSpeed, rb.velocity.y , -moveDirection.y * moveSpeed);
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
