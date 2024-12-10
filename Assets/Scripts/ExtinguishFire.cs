using UnityEngine;
using UnityEngine.VFX;

public class ExtinguishFire : MonoBehaviour
{
    [SerializeField] VisualEffect fireEffect;

    bool smokePlayed;
    [SerializeField] GameObject smokePrefab;
    GameObject smokeInstance;
    ParticleSystem smokeParticles;

    private void Start()
    {
        smokePlayed = false;
        fireEffect = GetComponent<VisualEffect>();
        smokeInstance = Instantiate(smokePrefab, fireEffect.transform.position, fireEffect.transform.rotation); //If smoke rotation is off check here
        smokeParticles = smokeInstance.GetComponent<ParticleSystem>();
        fireEffect.Play();
    }

    //private void OnParticleTrigger()
    //{
    //    if (smokeParticles != null)
    //    {
    //        fireEffect.SetFloat("Smoke Rate", 0f);
    //        fireEffect.SetFloat("Flames Rate", 0f);
    //        fireEffect.SetFloat("Sparks Rate", 0f);
    //        fireEffect.SetFloat("Spark Burst Rate Max", 0f);
    //        fireEffect.SetFloat("Spark Burst Rate Min", 0f);
    //        //if (!smokePlayed)
    //        //{
    //        //    smokePlayed = true;
    //        //}
    //        smokeParticles.Play();
            
    //        Destroy(smokeInstance, smokeParticles.main.duration + smokeParticles.main.startLifetime.constantMax);
    //    }
    //}

    //private void OnParticleCollision(GameObject other)
    //{
    //    if (other.CompareTag("Fire"))
    //    {
    //        fireEffect.SetFloat("Smoke Rate", 0f);
    //        fireEffect.SetFloat("Flames Rate", 0f);
    //        fireEffect.SetFloat("Sparks Rate", 0f);
    //        fireEffect.SetFloat("Spark Burst Rate Max", 0f);
    //        fireEffect.SetFloat("Spark Burst Rate Min", 0f);
    //        smokeParticles.Play();
    //        Destroy(smokeInstance, smokeParticles.main.duration + smokeParticles.main.startLifetime.constantMax);
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Fire"))
    //    {
    //        fireEffect.SetFloat("Smoke Rate", 0f);
    //        fireEffect.SetFloat("Flames Rate", 0f);
    //        fireEffect.SetFloat("Sparks Rate", 0f);
    //        fireEffect.SetFloat("Spark Burst Rate Max", 0f);
    //        fireEffect.SetFloat("Spark Burst Rate Min", 0f);
    //        smokeParticles.Play();
    //        Destroy(smokeInstance, smokeParticles.main.duration + smokeParticles.main.startLifetime.constantMax);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Water")
        {
            fireEffect.SetFloat("Smoke Rate", 0f);
            fireEffect.SetFloat("Flames Rate", 0f);
            fireEffect.SetFloat("Sparks Rate", 0f);
            fireEffect.SetFloat("Spark Burst Rate Max", 0f);
            fireEffect.SetFloat("Spark Burst Rate Min", 0f);
            //if (!smokePlayed)
            //{
            //    smokePlayed = true;
            //}
            smokeParticles.Play();
            Destroy(smokeInstance, smokeParticles.main.duration + smokeParticles.main.startLifetime.constantMax);
        }
    }
}