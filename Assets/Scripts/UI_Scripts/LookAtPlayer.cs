using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] GameObject player; // Assign player in the Inspector

    void Update()
    {
        if (player != null) // Check to avoid errors
        {
            transform.LookAt(player.transform);
        }
    }
}

