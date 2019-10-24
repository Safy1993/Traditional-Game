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
        audioSource.Play();
        

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

    //Anbar Game Sound Effects 
    //1) Anber Game Start music
    public void AnberStartMusic()
    {
        audioSource.PlayOneShot(soundEffects[1], 0.5f);
    }
    //2)Hit can
    public void HitCan()
    {
        audioSource.PlayOneShot(soundEffects[0], 0.5f);
    }
    
    //3)HitGround
    public void CanHitGround()
    {
        audioSource.PlayOneShot(soundEffects[5], 0.5f);
    }
    //4) NextLevel
    public void NextLevelSoundEffect()
    {
        audioSource.PlayOneShot(soundEffects[6], 0.5f);
    }
    //5) LastLevel
    public void LastLevelSoundEffect()
    {
        audioSource.PlayOneShot(soundEffects[2], 0.5f);
    }
    //6) ReduceBall
    public void ReduceBallSoundEffect()
    {
        audioSource.PlayOneShot(soundEffects[2], 0.5f);
    }
    //7)DoubalScore
    public void DoubalScoreSoundEffect()
    {
        audioSource.PlayOneShot(soundEffects[2], 0.5f);
    }
    //8 shoot Ball Sound
    public void FlayBallSoundEffect()
    {
        audioSource.PlayOneShot(soundEffects[2], 0.5f);
    }
    //11 Game Over Sound
    public void GameOverSoundEffect()
    {
        audioSource.PlayOneShot(soundEffects[2], 0.5f);
    }
    //AudioManager.Instance.AnberStartMusic();
    //AudioManager.Instance.HitCan();
    //AudioManager.Instance.CanHitGround();
    //AudioManager.Instance.NextLevelSoundEffect();
    //AudioManager.Instance.LastLevelSoundEffect();
    //AudioManager.Instance.ReduceBallSoundEffect();
    //AudioManager.Instance.DoubalScoreSoundEffect();
    //AudioManager.Instance.FlayBallSoundEffect();
    //AudioManager.Instance.GameOverSoundEffect();
    //AudioManager.Instance.AnberStartMusic();











}
