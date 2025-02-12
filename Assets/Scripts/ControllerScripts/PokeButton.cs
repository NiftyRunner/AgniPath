using UnityEngine;

public class PokeButton : MonoBehaviour
{
    [SerializeField] Animator buttonAnimator;

    public void OnPlayerInteract()
    {
        buttonAnimator.SetBool("PlayerInteracting", true);
    }

    public void OnPlayerRelease()
    {
        buttonAnimator.SetBool("PlayerInteracting", false);
    }
}
