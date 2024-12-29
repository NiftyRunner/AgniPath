using UnityEngine;

public class WaterHoseController : MonoBehaviour
{
    [SerializeField] ParticleSystem waterParticle;
    [SerializeField] Transform defaultHoseTransform;

    Transform currentHoseTransform;

    private void Start()
    {
        currentHoseTransform = GetComponent<Transform>();
    }
    public void ActivateWater()
    {
        waterParticle.Play();
    }

    public void DeactivateWater() 
    { 
        waterParticle.Stop(); 
    }

    public void ResetPosition()
    {
        if (defaultHoseTransform != null)
        {
            currentHoseTransform = defaultHoseTransform;
            this.transform.position = defaultHoseTransform.position;
            this.transform.rotation = defaultHoseTransform.rotation;
        }
    }

}
