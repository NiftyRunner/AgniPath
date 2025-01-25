using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    [SerializeField] GameObject arrowImage;
    [SerializeField] HingeJoint joint;
    int count;

    void Start()
    {
        joint.useMotor = false;
        arrowImage.SetActive(false);
        count = 0;
    }

    private void Update()
    {
        if(count >= 2)
        {
            arrowImage.SetActive(true);
            StartCoroutine(MotorWorking());
        }
        else
        {
            //StopCoroutine(MotorWorking());
            joint.useMotor = false;
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

    IEnumerator MotorWorking()
    {
        yield return new WaitForSeconds(0.5f);
        joint.useMotor = true;
    }
}
