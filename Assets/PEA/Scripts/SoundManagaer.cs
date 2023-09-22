using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagaer : MonoBehaviour
{
    public static SoundManagaer instance = null;

    private AudioSource audioSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayBGM(AudioClip bgmClip)
    {
        audioSource.clip = bgmClip;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
