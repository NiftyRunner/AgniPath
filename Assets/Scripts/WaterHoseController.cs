using UnityEngine;

public class WaterHoseController : MonoBehaviour
{
    [SerializeField] ParticleSystem waterParticle;
    [SerializeField] Transform defaultHoseTransform;

    AudioSource waterSoundSource;
    Transform currentHoseTransform;

    private void Start()
    {
        currentHoseTransform = GetComponent<Transform>();
        waterSoundSource = GetComponent<AudioSource>();
    }
    public void ActivateWater()
    {
        waterParticle.Play();
        waterSoundSource.Play();
    }

    public void DeactivateWater() 
    { 
        waterParticle.Stop();
        waterSoundSource.Stop();
    }

    public void ResetPosition()
    {
        if (defaultHoseTransform != null)
        {
            currentHoseTransform = defaultHoseTransform;
            this.transform.position = defaultHoseTransform.position;
            this.transform.rotation = defaultHoseTransform.rotation;
            waterSoundSource.Stop();
        }
    }

}
