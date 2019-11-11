using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnberAdioManager : MonoBehaviour
{
   
        public static AnberAdioManager Instance { get; set; }
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


    //Anbar Game Sound Effects 
    public void ClickButton()
    {
        audioSource.PlayOneShot(soundEffects[0], 0.5f);
    }
    //1) Anber Game Start music


    ////2)Hit can
    //public void HitCan()
    //{
    //    audioSource.PlayOneShot(soundEffects[0], 0.5f);
    //}

    ////3)HitGround
    //public void CanHitGround()
    //{
    //    audioSource.PlayOneShot(soundEffects[5], 0.5f);
    //}
    //4) NextLevel
    public void NextLevelSoundEffect()
        {
            audioSource.PlayOneShot(soundEffects[1], 0.5f);
        }
        
        
        //7)DoubalScore
        public void DoubalScoreSoundEffect()
        {
            audioSource.PlayOneShot(soundEffects[3], 0.5f);
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






    }


