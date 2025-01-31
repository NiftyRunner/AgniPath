using UnityEngine;

public class WaterHitDetecter : MonoBehaviour
{
    ExtinguishFire hitFire;


    private void OnParticleCollision(GameObject other)
    {
        try
        {
            Debug.Log("Particle Collision" + other.name);
            if (other.CompareTag("Fire"))
            {
                hitFire = other.GetComponent<ExtinguishFire>();
                hitFire.ExtingushFire();
            }
        }
        catch (System.Exception e) {
            Debug.Log(e.ToString());    
        }
    }
}
