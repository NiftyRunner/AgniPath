using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentController : MonoBehaviour
{
    [SerializeField] Transform positionToReach;

    Animator animator;
    NavMeshAgent agent;

    void Start()
    {
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
    }
}
