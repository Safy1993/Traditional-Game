using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System;

public enum PutterState
{
    Idle,
    shooting,
    following
}



public class LevelManager : MonoBehaviour
{
    public PutterState CurrentState;
    public PutterControl paddle;
    public Rigidbody ball;
    public GameObject Line;
    public AudioSource winSound;
    public AudioSource hitball;
    public AudioSource buttonClickSound;
    public AudioSource backgroundSound;
    public AudioSource ballInHole;
    public GameObject arrowLevel1;
    public GameObject arrowLevel2;

    public GameObject nextLevel;

    public static LevelManager Instance;
 

    public float timer = 2;
    // Start is called before the first frame update
    void Start()
    {
       backgroundSound.Play();
      
        Instance = this;

       

        if (PlayerPrefs.GetInt("level", 0) == 0)
        {
            arrowLevel1.SetActive(true);
            arrowLevel2.SetActive(false);
        }
        else
        {
            arrowLevel1.SetActive(false);
            arrowLevel2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetKey(KeyCode.N))
        {
            onNextLevel();
        }
        switch (CurrentState)
        {

            case PutterState.Idle:

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {

                    Shoot();

                }




                break;


            case PutterState.shooting:



                if (ball.velocity.magnitude >= 0.01f)
                {
                    CurrentState = PutterState.following;
                }


                break;


            case PutterState.following:



                if (ball.velocity.magnitude <= 0.05f)
                {

                    //timer -= Time.deltaTime;

                    // if (timer < 0)
                    // {

                    //     if (UIMang.instance.score == 0)
                    //     {
                    //         UIMang.instance.ShowGameOver();
                    //     }
                    //     else
                    //     {
                    print("Idel state >>> ");
                    CurrentState = PutterState.Idle;
                    Line.SetActive(true);
                    paddle.MovePlayer();
                    timer = 2;
                    // }
                    // }
                }

                break;

        }


    }

    public void Shoot()
    {
        paddle.Shoot();
        CurrentState = PutterState.shooting;
        Line.SetActive(false);
        //MidhrapAudioManager.Instance.HitSoundEffect();
        hitball.Play();
    }

    public void onNextLevel()
    {
        buttonClickSound.Play();
      //  MidhrapAudioManager.Instance.ButtonHitSoundEffect();
        if (PlayerPrefs.GetInt("level", 0) == 0)
        {
            PlayerPrefs.SetInt("level", 1);
        }
        else
        {
            PlayerPrefs.SetInt("level", 0);
        }

        SceneManager.LoadScene("MathrabGame");
    }

    internal void FinishedLevel()
    {
        UIMang.instance.endText.text = "you win";
        UIMang.instance.endText.enabled = true;

        nextLevel.SetActive(true);
        //MidhrapAudioManager.Instance.BallInHole();
        // MidhrapAudioManager.Instance.yourAreWinSound();
        ballInHole.Play();
        winSound.Play();
        
        PlayerPrefs.SetInt("Score", UIMang.instance.score);

    }
}
