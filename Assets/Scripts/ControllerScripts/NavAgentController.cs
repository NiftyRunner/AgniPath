using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; // Needed for scene transition

public class NavAgentController : MonoBehaviour
{
    [SerializeField] Transform positionToReach;
    [SerializeField] Canvas endCanvas;
    [SerializeField] Canvas finalCanvas;
    [SerializeField] string sceneToLoad; // Assign scene name in Inspector
    [SerializeField] LevelManager_Parth levelManager;

    Animator animator;
    NavMeshAgent agent;
    bool reached;

    void Start()
    {
        reached = false;
        finalCanvas.enabled = false;

        if (endCanvas != null)
        {
            endCanvas.gameObject.SetActive(false); // Ensure UI starts disabled
            //endCanvasFPP.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("EndCanvas is not assigned in the Inspector!");
        }

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

                    if (endCanvas != null)
                    {
                        endCanvas.gameObject.SetActive(true); // Enable UI
                        levelManager.isLevelRunning = false;
                        finalCanvas.enabled = true;
                        //endCanvasFPP.gameObject.SetActive(true);
                        StartCoroutine(ChangeSceneAfterDelay(5f)); // Start scene change
                    }
                }
            }
        }
    }

    IEnumerator ChangeSceneAfterDelay(float delay)  
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToLoad); // Load assigned scene
    }
}
