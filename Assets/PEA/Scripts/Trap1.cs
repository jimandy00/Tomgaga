using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    public ParticleSystem[] fires;
    public AudioClip fireAudioClip;

    public void Fire()
    {
        foreach(ParticleSystem ps in fires)
        {
            ps.Play();
        }

        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlaySFX(fireAudioClip);
        }
        //fireAudioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fire();
            other.GetComponent<PlayerDie>().Die();
        }
    }
}
