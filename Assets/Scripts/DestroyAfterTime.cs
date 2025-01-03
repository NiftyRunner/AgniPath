using UnityEngine;

public class DestroyUIAfterTime : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 5f; // Time in seconds before destruction

    private void Start()
    {
        // Destroy the GameObject after the specified time
        Destroy(gameObject, timeToDestroy);
    }
}
