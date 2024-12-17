using System.Collections;
using UnityEngine;

public class PersonRescue : MonoBehaviour
{
    [SerializeField] float timeToHold = 3f;
    [SerializeField] float timer;
    bool increaseTimer;

    void Start()
    {
        timer = 0f;
        increaseTimer = false;
    }

    private void Update()
    {
        if (increaseTimer)
        {
            timer += Time.deltaTime;
        }

        if (timer >= timeToHold)
        {
            Debug.Log("Person Rescued");
            increaseTimer = false;
            timer = 0f;
        }
    }

    public void TouchedHands()
    {
        increaseTimer = true;
    }

    public void ReleasedHands()
    {
       increaseTimer = false;
       timer = 0f;
    }

}
