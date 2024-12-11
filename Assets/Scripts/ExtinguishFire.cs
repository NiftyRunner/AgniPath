using UnityEngine;
using UnityEngine.VFX;

public class ExtinguishFire : MonoBehaviour
{
    [SerializeField] VisualEffect fireEffect;

    bool isSmokePlayed;
    [SerializeField] GameObject smokePrefab;
    GameObject smokeInstance;
    ParticleSystem smokeParticles;

    private void Start()
    {
        isSmokePlayed = false;
        fireEffect = GetComponent<VisualEffect>();
        smokeInstance = Instantiate(smokePrefab, fireEffect.transform.position, fireEffect.transform.rotation); //If smoke rotation is off check here
        smokeParticles = smokeInstance.GetComponent<ParticleSystem>();
        fireEffect.Play();
    }

    public void ExtingushFire()
    {
        fireEffect.SetFloat("Smoke Rate", 0f);
        fireEffect.SetFloat("Flames Rate", 0f);
        fireEffect.SetFloat("Sparks Rate", 0f);
        fireEffect.SetFloat("Spark Burst Rate Max", 0f);
        fireEffect.SetFloat("Spark Burst Rate Min", 0f);
        if (smokeParticles != null && !isSmokePlayed) 
        {
            smokeParticles.Play();
            Destroy(smokeInstance, smokeParticles.main.duration + smokeParticles.main.startLifetime.constantMax);
            isSmokePlayed=true;
        }
    }
}