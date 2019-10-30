using UnityEngine.Audio;
using System;
using UnityEngine;

public class MidhrapAudioManager : MonoBehaviour
{
    public static MidhrapAudioManager Instance { get; set; }
    [SerializeField] AudioClip[] soundEffects;
    AudioSource audioSource1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
      audioSource1 = GetComponent<AudioSource>();
        backgroundSound();



    }

    public void BallInHole()
    {
        audioSource1.PlayOneShot(soundEffects[0], 1f);
    }
    public void HitSoundEffect()
    {
        audioSource1.PlayOneShot(soundEffects[1], 1f);
    }
    public void ButtonHitSoundEffect()
    {
        audioSource1.PlayOneShot(soundEffects[2], 0.5f);
    }

    public void backgroundSound()
    {
        audioSource1.PlayOneShot(soundEffects[3], 0.5f);
    }

    public void yourAreWinSound()
    {
        audioSource1.PlayOneShot(soundEffects[4], 0.5f);
    }


}
