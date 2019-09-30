using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject[] allBallImg;
    public Sprite enabledBallImg;
    public Sprite diabledBallImg;

    public GameObject backFg;
    public GameObject GameUI,HomeUI;
    public GameObject gameScence;
    
    public int score;
    public Text scoreText;

    //public int scoreMulitplier;
    //public GameObject scoreMltiImage;
    //public Text scoreMultiText;


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
        gameScence.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    IEnumerator StartRoutine()
    {
        ShowBlackFade();
        yield return new WaitForSeconds(0.5f);
        HomeUI.SetActive(false);
        gameScence.SetActive(true);
        GameUI.SetActive(true);
        GameManager.instance.readyToShoot = true;
        

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
        //score += scoreMulitplier*1;
        score +=1;
        scoreText.text = score.ToString();
    }
    //public void UpdateScoreMultiplier()
    //{
    //    if (GameManager.instance.shotedBall==1)
    //    {
    //        scoreMulitplier++;
    //        scoreMltiImage.SetActive(true);
    //        scoreMultiText.text = scoreMulitplier.ToString();

    //    }
    //    else
    //    {
    //        scoreMulitplier=1;
    //        scoreMltiImage.SetActive(false);

    //    }
    //}
}
