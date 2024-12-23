using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] List<GameObject> fires;
    [SerializeField] bool isRoomOne;

    void Start()
    {
        if (!isRoomOne)
        {
            foreach (GameObject fire in fires)
            {
                fire.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject fire in fires)
            {
                fire.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject fire in fires)
            {
                fire.SetActive(false);
            }
        }
    }
}
