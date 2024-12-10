using UnityEngine;

public class WaterHoseController : MonoBehaviour
{
    [SerializeField] ParticleSystem waterParticle;
    
    public void ActivateWater()
    {
        waterParticle.Play();
    }

    public void DeactivateWater() 
    { 
        waterParticle.Stop(); 
    }

}
