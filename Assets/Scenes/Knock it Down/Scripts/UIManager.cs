using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject[] allBallImg;

    public Sprite enabledBallImg;
    public Sprite diabledBallImg;

    public GameObject backFg;
    public GameObject GameUI;
    public GameObject HomeUI;
    public GameObject gameScence;
    
    public int score;
    public Text scoreText;
    public int highscore;
    public Text highscoreText;

    public int scoreMulitplier=1;
    public GameObject scoreMltiImage;
    public Text scoreMultiText;

    public static bool isRestart;

    public GameObject PausePanel;
    public GameObject gameOverUI;

    public Text gearRotationText;

    void Awake()
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
    // Start is called before the first frame update
    void Start()
    {
        HomeUI.SetActive(true);
        ////gameScence.SetActive(false);
        if (isRestart)
        {
            isRestart = false;
           HomeUI.SetActive(false);
            gameScence.SetActive(true);
            GameManager.instance.StartGame();

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            StartCoroutine(StartRoutine());
        }
    }

    public void UpdateBallIcons()
    {
        int ballCount = GameManager.instance.totalBalls;
        for (int i=0;i<5;i++)
        {
            if (i<ballCount)
            {
                allBallImg[i].GetComponent<Image>().sprite = enabledBallImg;
            }
            else
            {
                allBallImg[i].GetComponent<Image>().sprite = diabledBallImg;
            }

        }

    }

    public void StartButton()
    {
        StartCoroutine(StartRoutine());



    }
    public void B_Restart()
    {
        StartCoroutine(RestartStartRoutine());
      
    }

    public void B_Back()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void B_Back_Yes()
    {
        Time.timeScale =1;
        SceneManager.LoadScene(1);
    }
    public void B_Back_No()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    IEnumerator StartRoutine()
    {
        ShowBlackFade();
        yield return new WaitForSeconds(0.5f);
        HomeUI.SetActive(false);
        gameScence.SetActive(true);
        GameUI.SetActive(true);

        GameManager.instance.StartGame();
        //GameManager.instance.readyToShoot = true;

    }

    public void ShowBlackFade()
    {
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        backFg.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        backFg.SetActive(false);

    }

    public void UpdateScore()
    {
        score += scoreMulitplier*1;
        
        scoreText.text = score.ToString();
        
    }
    //public void UpdateScoreMultiplier()
    //{
    //    if (GameManager.instance.shotedBall == 1)
    //    {
    //        scoreMulitplier++;
    //        scoreMltiImage.SetActive(true);
    //        scoreMultiText.text = scoreMulitplier.ToString();

    //    }
    //    else
    //    {
    //        scoreMulitplier = 1;
    //        scoreMltiImage.SetActive(false);

    //    }
    //}
    IEnumerator RestartStartRoutine()
    {
        
       
        ShowBlackFade();
        isRestart = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
      
    }
    public void HightScore()
    {
        
            highscore = score;
            highscoreText.text = "Your Score:" + score;

            PlayerPrefs.SetInt("highscore", highscore);


        
    }
   
}
