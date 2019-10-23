using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle audioToggle;
    public GameObject chooseGame;
    public GameObject MainMenue;

    public GameObject MainCanvas;
    public GameObject midhrabGameObject;
   // public GameObject AnbarGameObject;

    void Start()
    {
        int mute = PlayerPrefs.GetInt("Mute", 0);
        audioToggle.isOn = mute == 1;

    }

    public void PlayGame()
    {
        chooseGame.SetActive(true);

        HitButtonSound();
        MainMenue.SetActive(false);


    }

    public void ExitGame()
    {
   
        Debug.Log("Quit!");
        Application.Quit();
     
    }

    public void MathrabGame()
    {


        midhrabGameObject.SetActive(true);
        HitButtonSound();
        MainCanvas.SetActive(false);



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

   





}
