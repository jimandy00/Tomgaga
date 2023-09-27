using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles2_Fragment : MonoBehaviour
{
    public ParticleSystem fragmentParticle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fragmentParticle.Play();
            //other.GetComponentInChildren<CamShake>().ShakeCamera();
        }
    }
}
