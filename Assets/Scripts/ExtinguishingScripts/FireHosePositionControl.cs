using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHosePositionControl : MonoBehaviour
{
    [SerializeField] Transform defaultTransform;

    bool isGrabbed;

    void Start()
    {
        isGrabbed = false;
        transform.position = defaultTransform.position;
        transform.rotation = defaultTransform.rotation;
    }

    void Update()
    {
        if (!isGrabbed)
        {
            transform.position = defaultTransform.position;
            transform.rotation = defaultTransform.rotation;
        }
    }

    public void Grabbed()
    {
        isGrabbed = true;
    }

    public void Released()
    {
        isGrabbed = false;
    }
}
