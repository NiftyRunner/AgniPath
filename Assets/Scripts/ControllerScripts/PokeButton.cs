using UnityEngine;

public class PokeButton : MonoBehaviour
{
    [SerializeField] Animator buttonAnimator;
    [SerializeField] AudioSource buttonSource;

    private bool wasPlayingBeforePause = false; // Tracks if audio was playing before pause

    public void OnPlayerInteract()
    {
        if (!buttonSource.isPlaying)
        {
            buttonSource.Play();
            wasPlayingBeforePause = true; // Mark that audio was playing
        }
        else
        {
            wasPlayingBeforePause = false; // It was already playing, no need to resume later
        }

        Invoke("PauseAudio", 1f);
        buttonAnimator.SetBool("PlayerInteracting", true);
    }

    public void OnPlayerRelease()
    {
        if (wasPlayingBeforePause) // Only resume if it was playing before pause
        {
            buttonSource.UnPause();
        }
        buttonAnimator.SetBool("PlayerInteracting", false);
    }

    void PauseAudio()
    {
        if (buttonSource.isPlaying)
        {
            buttonSource.Pause();
        }
    }
}
