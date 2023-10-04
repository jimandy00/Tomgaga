using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum BGM
    {
        MainTheme,
        Prologue,
        PlayTheme,
        Puzzle,
        EngindTheme,
        FaillingLoad
    }

    public static SoundManager instance = null;

    private AudioSource audioSource;

    public AudioClip[] bgmClips;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
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

    public void PlayBGM(BGM bgm)
    {
        print(bgmClips[(int)bgm]);
        audioSource.clip = bgmClips[(int)bgm];
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
