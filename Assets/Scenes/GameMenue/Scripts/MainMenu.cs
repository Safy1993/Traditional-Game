using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle audioToggle;
    public GameObject chooseGame;
    public GameObject MainMenuGameobject;

   // public GameObject MainCanvas;
 //   public GameObject midhrabGameObject;
   // public GameObject AnbarGameObject;

    void Start()
    {
        int mute = PlayerPrefs.GetInt("Mute", 0);
        audioToggle.isOn = mute == 1;

    }

     void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            PlayGame();
           
        }
        if (Input.GetKey(KeyCode.M))
        {
            MathrabGame();
        }

        if (Input.GetKey(KeyCode.A))
        {
            AmperGame();
        }

       

        if (Input.GetKey(KeyCode.P))
        {
            MathrabGame();
            Debug.Log("play again");
        }

    }

    public void PlayGame()
    {
        chooseGame.SetActive(true);
        HitButtonSound();
        MainMenuGameobject.SetActive(false);


    }

    public void ExitGame()
    {
   
        Debug.Log("Quit!");
        Application.Quit();
     
    }

    public void MathrabGame()
    {
        PlayerPrefs.SetInt("game", 0);

        SceneManager.LoadScene("MathrabGame");
        HitButtonSound();
    }


    public void backMainMenuchooseGame()
    {

        MainMenuGameobject.SetActive(true);
        chooseGame.SetActive(false);
        HitButtonSound();

    }

    public void AmperGame()
    {
        PlayerPrefs.SetInt("game", 1);

        SceneManager.LoadScene("MathrabGame");
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
