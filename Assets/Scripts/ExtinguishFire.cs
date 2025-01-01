using UnityEngine;
using UnityEngine.VFX;

public class ExtinguishFire : MonoBehaviour
{
    VisualEffect fireEffect;

    bool isSmokePlayed;
    [SerializeField] GameObject smokePrefab;
    [SerializeField] Vector3 smokeScale;
    [SerializeField] AudioClip extinguishClip;
    AudioSource extinguishSource;
    GameObject smokeInstance;
    ParticleSystem smokeParticles;

    private void Start()
    {
        isSmokePlayed = false;
        fireEffect = GetComponent<VisualEffect>();
        extinguishSource = GetComponent<AudioSource>();
        smokeInstance = Instantiate(smokePrefab, fireEffect.transform.position, fireEffect.transform.rotation); //If smoke rotation is off check here
        smokeParticles = smokeInstance.GetComponent<ParticleSystem>();
        smokeInstance.transform.localScale = smokeScale;
        fireEffect.Play();
        extinguishSource.Play();
    }


    public void ExtingushFire()
    {
        fireEffect.SetFloat("Smoke Rate", 0f);
        fireEffect.SetFloat("Flames Rate", 0f);
        fireEffect.SetFloat("Sparks Rate", 0f);
        fireEffect.SetFloat("Spark Burst Rate Max", 0f);
        fireEffect.SetFloat("Spark Burst Rate Min", 0f);
        extinguishSource.Stop();
        if (smokeParticles != null && !isSmokePlayed) 
        {
            smokeParticles.Play();
            extinguishSource.PlayOneShot(extinguishClip);
            Destroy(smokeInstance, smokeParticles.main.duration + smokeParticles.main.startLifetime.constantMax);
            isSmokePlayed=true;
        }
    }
}