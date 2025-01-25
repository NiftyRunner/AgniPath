using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorOpen : MonoBehaviour
{
    [SerializeField] HingeJoint doorJoint;

    // Start is called before the first frame update
    void Start()
    {
        doorJoint.useMotor = false;
    }

    public void ActivateMotor()
    {
        StartCoroutine(Motor());
    }

    public void DeactivateMotor() 
    {
        doorJoint.useMotor = false; 
    }

    IEnumerator Motor()
    {
        yield return new WaitForSeconds(1);
        doorJoint.useMotor = true;
        
    }
    
}
