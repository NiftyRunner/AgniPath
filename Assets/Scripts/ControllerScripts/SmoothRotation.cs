using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    //public bool rotStart = false;
    //[SerializeField] Quaternion currentRotation;
    //[SerializeField] Quaternion targetRotation;
    //[SerializeField] float lerpSpeed = 0.1f;

    //private void Start()
    //{
    //    rotStart = false;
    //    currentRotation = transform.rotation;
    //}

    //void Update()
    //{
    //    if (rotStart) 
    //    { 
    //        currentRotation = transform.rotation;
    //        Quaternion rotation = targetRotation;
    //        transform.rotation = Quaternion.Slerp(currentRotation, rotation, lerpSpeed);
    //    }
    //}

    public bool rotStart = false;
    [SerializeField] Quaternion targetRotation;
    [SerializeField] private float lerpSpeed = 2f; // Increased for smoother rotation

    private void Start()
    {
        rotStart = false;
    }

    void Update()
    {
        if (rotStart)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerpSpeed * Time.deltaTime);

            // Stop rotating if close enough
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                rotStart = false; // Stop unnecessary updates
            }
        }
    }

    public void SetTargetRotation(Quaternion newRotation)
    {
        targetRotation = newRotation;
        rotStart = true;
    }
}
