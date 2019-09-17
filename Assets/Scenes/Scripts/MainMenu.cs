using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle audioToggle;

    void Start()
    {
        int mute = PlayerPrefs.GetInt("Mute", 0);
        audioToggle.isOn = mute == 1;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Another");
        AudioManager.Instance.ButtonHitSoundEffect();
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void MuteSounds()
    {
        if (audioToggle.isOn)
            PlayerPrefs.SetInt("Mute", 1);
        else
            PlayerPrefs.SetInt("Mute", 0);

    }


    
}
