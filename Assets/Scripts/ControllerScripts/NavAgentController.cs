using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentController : MonoBehaviour
{
    [SerializeField] Transform positionToReach;
    [SerializeField] Canvas endCanvas;

    Animator animator;
    NavMeshAgent agent;
    bool reached;

    void Start()
    {
        reached = false;
        endCanvas.enabled = false;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        agent.SetDestination(positionToReach.position);
        if (agent.velocity.magnitude > 0)
        {
            animator.SetBool("hasVelocity", true);
        }
        else
        {
            animator.SetBool("hasVelocity", false);
        }

        if (!agent.pathPending && !reached)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    reached = true;
                    Debug.Log("Reached");
                    endCanvas.enabled = true;
                }
            }
        }
    }
}
