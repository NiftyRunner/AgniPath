using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    [Header("Ladder Objects")]
    [SerializeField] Transform platform;
    [SerializeField] Transform ladderBase;
    [SerializeField] Transform ladderExtension;
    [SerializeField] AudioSource platformSource;

    [Header("Movement Values")]
    [SerializeField] float heightStep = 0.5f;
    [SerializeField] float maxHeight = 10f;
    [SerializeField] float minHeight = 0f;
    [SerializeField] float extensionLength = 1f;
    [SerializeField] float upDownSpeed = 2f;

    float currentHeight;
    bool goingUp;
    bool goingDown;
    bool isMoving;

    private void Start()
    {
        currentHeight = platform.position.y;
        minHeight = currentHeight;
        isMoving = false;
    }

    private void FixedUpdate()
    {
        if (goingUp && currentHeight < maxHeight)
        {
            GoUp();
        }
        else if (goingDown && currentHeight > minHeight)
        {
            GoDown();
        }
        else
        {
            StopAudio();
        }
    }

    public void SetGoingUp()
    {
        if (currentHeight < maxHeight)
        {
            goingUp = true;
            goingDown = false;
            PlayAudio();
        }
    }

    public void UnsetGoingUp()
    {
        goingUp = false;
    }

    public void SetGoingDown()
    {
        if (currentHeight > minHeight)
        {
            goingDown = true;
            goingUp = false;
            PlayAudio();
        }
    }

    public void UnsetGoingDown()
    {
        goingDown = false;
    }

    private void GoUp()
    {
        if (currentHeight < maxHeight)
        {
            currentHeight += heightStep * Time.deltaTime * upDownSpeed;
            platform.position = new Vector3(platform.position.x, currentHeight, platform.position.z);
            UpdateLadder();
            isMoving = true;
        }
        else
        {
            StopAudio();
        }
    }

    private void GoDown()
    {
        if (currentHeight > minHeight)
        {
            currentHeight -= heightStep * Time.deltaTime * upDownSpeed;
            platform.position = new Vector3(platform.position.x, currentHeight, platform.position.z);
            UpdateLadder();
            isMoving = true;
        }
        else
        {
            StopAudio();
        }
    }

    private void StopAudio()
    {
        if (isMoving && platformSource.isPlaying)
        {
            platformSource.Stop();
        }
        isMoving = false;
    }

    private void PlayAudio()
    {
        if (!platformSource.isPlaying && (goingUp || goingDown))
        {
            platformSource.Play();
        }
    }

    private void UpdateLadder()
    {
        Vector3 direction = platform.position - ladderBase.position;
        float distance = direction.magnitude;
        Vector3 normalizedDirection = direction.normalized;
        ladderExtension.position = ladderBase.position + normalizedDirection * (distance - extensionLength);
        ladderExtension.LookAt(platform.position);
        ladderBase.LookAt(platform.position);
    }
}
