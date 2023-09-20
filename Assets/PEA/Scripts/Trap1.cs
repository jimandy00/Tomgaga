using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    private ParticleSystem[] fires;

    void Start()
    {
        fires = new ParticleSystem[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            fires[i] = transform.GetChild(i).GetComponent<ParticleSystem>();
        }
    }

    public void Fire()
    {
        foreach(ParticleSystem ps in fires)
        {
            ps.Play();
        }
    }
}
