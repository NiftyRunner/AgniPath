using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDebris : MonoBehaviour
{
    [SerializeField] List<SmoothRotation> rotationObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var obj in rotationObjects)
            {
                obj.rotStart = true;
            }
        }
    }
}
