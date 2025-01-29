using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    [Header("Ladder Objects")]
    [SerializeField] Transform platform;
    [SerializeField] Transform ladderBase;
    [SerializeField] Transform ladderExtension;

    [Header("Movement Values")]
    [SerializeField] float heightStep = 0.5f;
    [SerializeField] float maxHeight = 10f;
    [SerializeField] float minHeight = 0f;
    [SerializeField] float extensionLength = 1f; // Length of each extension
    [SerializeField] float upDownSpeed = 2f;

    Vector3 currentDirection;
    float currentHeight;

    bool goingUp;
    bool goingDown;

    private void Start()
    {
        currentDirection = transform.localPosition;
        currentHeight = platform.position.y;
        minHeight = currentHeight;
        GoUp();
    }

    private void FixedUpdate()
    {
        if (goingUp)
        {
            GoUp();
        }

        if (goingDown)
        {
            GoDown();
        }

    }

    public void SetGoingUp()
    {
        goingUp = true;
    }

    public void UnsetGoingUp()
    {
        goingUp = false;
    }

    public void SetGoingDown()
    {
        goingDown = true;
    }

    public void UnsetGoingDown()
    {
        goingDown = false;
    }

    public void GoUp()
    {
        if (currentHeight < maxHeight)
        {
            currentHeight += heightStep * Time.deltaTime * upDownSpeed;
            platform.position = new Vector3(platform.position.x, currentHeight, platform.position.z);
            UpdateLadder();
        }
    }

    public void GoDown()
    {
        if (currentHeight > minHeight)
        {
            currentHeight -= heightStep * Time.deltaTime * upDownSpeed;
            platform.position = new Vector3(platform.position.x, currentHeight, platform.position.z);
            UpdateLadder();
        }
    }

    //private void UpdateLadder()
    //{

    //    Vector3 previousDirection = currentDirection;

    //    // Calculate the direction vector between the platform and the ladder base
    //    Vector3 direction = platform.position - ladderBase.position;
    //    Debug.Log(direction);
    //    float heightDifference = direction.y;
    //    //Debug.Log(heightDifference);
    //    float lengthDifference = direction.z;

    //    currentDirection = direction;

    //    Vector3 distanceDifference = currentDirection - previousDirection;
    //    Debug.Log(distanceDifference);
    //    ladderExtension.position = new Vector3(ladderExtension.position.x + distanceDifference.x, ladderExtension.position.y + distanceDifference.y, ladderExtension.position.z + distanceDifference.z);

    //    ladderBase.LookAt(platform.position);
    //}

    private void UpdateLadder()
    {
        // Calculate the direction vector from the ladder base to the platform
        Vector3 direction = platform.position - ladderBase.position;

        // Get the distance between the ladder base and the platform
        float distance = direction.magnitude;

        // Normalize the direction vector to ensure consistent alignment
        Vector3 normalizedDirection = direction.normalized;

        // Position the ladder extension to start at the ladder base
        ladderExtension.position = ladderBase.position;

        // Move the ladder extension forward along the normalized direction to cover the gap
        ladderExtension.position += normalizedDirection * (distance - extensionLength);

        // Rotate the ladder extension to align with the direction to the platform
        ladderExtension.LookAt(platform.position);

        // Align the base to face the platform
        ladderBase.LookAt(platform.position);
    }



}
