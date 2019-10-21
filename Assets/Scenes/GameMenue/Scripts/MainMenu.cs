﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle audioToggle;
    public GameObject chooseGame;

    void Start()
    {
        int mute = PlayerPrefs.GetInt("Mute", 0);
        audioToggle.isOn = mute == 1;
    }

    public void PlayGame()
    {
        chooseGame.SetActive(true);

        HitButtonSound();


    }

    public void ExitGame()
    {
   
        Debug.Log("Quit!");
        Application.Quit();
     
    }

    public void MathrabGame()
    {
        SceneManager.LoadScene("MathrupGame");
        HitButtonSound();


    }

    public void AmperGame()
    {
        SceneManager.LoadScene("AmperGame");
        HitButtonSound();


    }

    public void MuteSounds()
    {
   
        if (audioToggle.isOn)
            PlayerPrefs.SetInt("Mute", 1);
           
        else
            PlayerPrefs.SetInt("Mute", 0);
        
    }
    public void HitButtonSound()
    {
        AudioManager.Instance.HitSoundEffect();
    }

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        chooseGame.SetActive(true);

    //        HitButtonSound();
    //    }
    //    if (Input.GetKey(KeyCode.B))
    //    {
    //        if (audioToggle.isOn)
    //            PlayerPrefs.SetInt("Mute", 1);

    //        else
    //            PlayerPrefs.SetInt("Mute", 0);
    //    }

    //}



}
