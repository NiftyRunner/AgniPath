using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    [SerializeField] GameObject arrowImage;
    int count;

    void Start()
    {
        arrowImage.SetActive(false);
        count = 0;
    }

    private void Update()
    {
        if(count >= 2)
        {
            arrowImage.SetActive(true);
        }
        else
        {
            arrowImage.SetActive(false);
        }
    }

    public void IncreaseCount()
    {
        count++;
    }

    public void DecreaseCount()
    {
        count--;
    }
}
