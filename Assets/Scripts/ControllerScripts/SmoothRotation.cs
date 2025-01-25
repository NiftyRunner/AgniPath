using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    public bool rotStart = false;
    [SerializeField] Quaternion currentRotation;
    [SerializeField] Quaternion targetRotation;
    [SerializeField] float lerpSpeed = 0.1f;

    private void Start()
    {
        rotStart = false;
        currentRotation = transform.rotation;
    }

    void Update()
    {
        if (rotStart) 
        { 
            currentRotation = transform.rotation;
            Quaternion rotation = targetRotation;
            transform.rotation = Quaternion.Slerp(currentRotation, rotation, lerpSpeed);
        }
    }
}
