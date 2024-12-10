using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ExtinguishFire : MonoBehaviour
{
    VisualEffect fireEffect;

    [SerializeField] GameObject smokePrefab;
    GameObject smokeInstance;
    ParticleSystem smokeParticles;

    private void Start()
    {
        fireEffect = GetComponent<VisualEffect>();
        smokeInstance = Instantiate(smokePrefab, transform.position, Quaternion.identity);
        smokeParticles = smokeInstance.GetComponent<ParticleSystem>();
        fireEffect.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            fireEffect.SetFloat("Smoke Rate", 0f);
            fireEffect.SetFloat("Flames Rate", 0f);
            fireEffect.SetFloat("Sparks Rate", 0f);
            fireEffect.SetFloat("Spark Burst Rate Max", 0f);
            fireEffect.SetFloat("Spark Burst Rate Min", 0f);
            smokeParticles.Play();
            Destroy(smokeInstance, smokeParticles.main.duration + smokeParticles.main.startLifetime.constantMax);
        }
    }
}
