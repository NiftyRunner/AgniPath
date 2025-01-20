using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    [Header("Ladder Objects")]
    [SerializeField] Transform platform;
    [SerializeField] Transform ladderBase;
    [SerializeField] Transform[] ladderExtensions;

    [Header("Movement Values")]
    [SerializeField] float heightStep = 0.5f;
    [SerializeField] float maxHeight = 10f;
    [SerializeField] float minHeight = 0f;
    [SerializeField] float extensionLength = 1f; // Length of each extension
    [SerializeField] float rotationSpeed = 2f;

    float currentHeight;

    private void Start()
    {
        currentHeight = platform.position.y;
        minHeight = currentHeight;
    }

    public void GoUp()
    {
        if (currentHeight < maxHeight)
        {
            currentHeight += heightStep * Time.deltaTime;
            platform.position = new Vector3(platform.position.x, currentHeight, platform.position.z);
            UpdateLadder();
        }
    }

    public void GoDown()
    {
        if (currentHeight > minHeight)
        {
            currentHeight -= heightStep * Time.deltaTime;
            platform.position = new Vector3(platform.position.x, currentHeight, platform.position.z);
            UpdateLadder();
        }
    }

    private void UpdateLadder()
    {
        // Calculate the direction vector between the platform and the ladder base
        Vector3 direction = platform.position - ladderBase.position;
        Debug.Log(direction);
        float heightDifference = direction.y;
        float lengthDifference = -direction.z;

        ladderBase.LookAt(platform.position);

        // Calculate the angle the ladder needs to rotate to point towards the platform
        //float targetAngle = Mathf.Atan2(heightDifference, lengthDifference) * Mathf.Rad2Deg;

        //// Smoothly rotate the ladder base to the target angle
        //Quaternion targetRotation = Quaternion.Euler(targetAngle, 0, 0);
        //ladderBase.rotation = Quaternion.Lerp(ladderBase.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Adjust ladder extension positions
        //for (int i = 0; i < ladderExtensions.Length; i++)
        //{
        //    Transform extension = ladderExtensions[i];

        //    // Position each extension at a proportional distance
        //    float segmentHeight = (i + 1) * extensionLength;
        //    if (segmentHeight <= heightDifference)
        //    {
        //        extension.gameObject.SetActive(true);
        //        extension.localPosition = new Vector3(0, segmentHeight, 0); // Align along the y-axis
        //    }
        //    else
        //    {
        //        extension.gameObject.SetActive(false); // Hide extensions that exceed the height
        //    }
        //}
    }
}
