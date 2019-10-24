using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; }
    [SerializeField] AudioClip[] soundEffects;
    AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
        backgroundSound();



    }

    public void BallSoundEffect()
    {
        audioSource.PlayOneShot(soundEffects[0], 1f);
    }
    public void HitSoundEffect()
    {
        audioSource.PlayOneShot(soundEffects[1], 1f);
    }
    public void ButtonHitSoundEffect()
    {
        audioSource.PlayOneShot(soundEffects[2], 0.5f);
    }

    public void backgroundSound()
    {
        audioSource.PlayOneShot(soundEffects[3], 0.5f);
    }


}
