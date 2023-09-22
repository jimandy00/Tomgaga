using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    public ParticleSystem[] fires;
    public AudioSource fireAudioSource;

    public void Fire()
    {
        foreach(ParticleSystem ps in fires)
        {
            ps.Play();
        }
        fireAudioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fire();
        }
    }
}
