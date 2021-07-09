
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerBodyParticles : MonoBehaviour
{
    [SerializeField] float healthPerParticle;
    [SerializeField] AudioSource pickupAudio;


    List<Particle> enterParticles = new List<Particle>();
    ParticleSystem _particleSystem;
    Health player;



    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        player = GameObject.FindWithTag("Player").GetComponent<Health>();
        _particleSystem.trigger.SetCollider(0, player.GetComponent<Collider2D>());
    }

    private void Start()
    {
        EmissionModule emission = _particleSystem.emission;
        if (player.GetHealthFraction() < 0.2)
        {
            emission.burstCount *= 2;
        }
    }

    private void OnParticleTrigger()
    {
        _particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterParticles);
        if (enterParticles.Count != 0) pickupAudio.Play();
        for (int i = 0; i < enterParticles.Count; i++)
        {
            Particle subjectParticle = enterParticles[i];
            subjectParticle.remainingLifetime = 0;
            player.RestoreHealth(healthPerParticle);
            enterParticles[i] = subjectParticle;
        }

        _particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterParticles);


    }
}
