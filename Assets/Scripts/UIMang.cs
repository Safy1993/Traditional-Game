using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMang : MonoBehaviour
{
    public static UIMang instance;
    public GameObject[] allBallImg;
    public GameObject GameOverText;
    public GameObject WinText;
    public Text gearRotation;
    public Text endText;
    public Text timer;
    public Text textScore ;

    int minutes;
    int seconds;
    public float totalTime = 0f;
    public int score = 10 ; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(this);
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        UpdateLevelTimer(totalTime);

        if (totalTime > 10f)
        {
            score -= 1;
            textScore.text =" Score : " +  score; 
            totalTime = 0;
        }


        if (score == 0)
        {
            ShowGameOver();
           LevelManager.Instance.CurrentState = PutterState.Idle;
        }
    }




    internal void ShowGameOver()
    {
        endText.text = "Game Over";
        endText.enabled = true;
        GameOverText.SetActive(true);
    }


    public void UpdateLevelTimer(float totalSeconds)
    {
        minutes = Mathf.FloorToInt(totalSeconds / 60f);
        seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timer.text ="Time " +  minutes.ToString("00") + ":" + seconds.ToString("00");
    }



   



    public void UpdateBallIcons()
    {


        int ballCount = LevelManager.Instance.totalBalls;


        for (int i = 0; i < ballCount; i++)
        {

            if (i < ballCount)
            {
                allBallImg[i].GetComponent<Image>().color = Color.white;


            }
            else
            {
                allBallImg[i].GetComponent<Image>().color = Color.yellow;

            }


        }

    }


}
