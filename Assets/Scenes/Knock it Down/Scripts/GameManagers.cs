﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum GameState
{
    Idle,
    Inhand,
    Shot,
    ballMoving,
    gameover
}


public class GameManagers : MonoBehaviour
{
    public GameState CurrentState;

    public static GameManagers instance;
    public GameObject ball;
    Plane plane = new Plane(Vector3.forward, 0);
    public Transform Target;
    public float ballForce;
    public int totalBalls;
    public int currentLevel;
    public GameObject[] allLevels;
    public GameObject[] casSetGRB;

    public Balls ballScript;

    public int shotedBall;

    bool checkX;
    float timer;

    float gameTimer = 0;

    public Transform handController;

    bool lastShot;
    // Start is called before the first frame update
    //float xrot = -1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        CurrentState = GameState.gameover;
    }

    public void StartGame()
    {
        CurrentState = GameState.Idle;
    }

    // Update is called once per frame
    void Update()
    {


        // UIManager.instance.gearRotationText.text = " Gear Rotation =  [ " + handController.localRotation + " ]";

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;

        }
        Vector3 dir = Target.position - ball.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));


        // if (Input.GetMouseButton(0))
        // {
        //shoot the ball
        //ball.GetComponent<Animator>().enabled = false;
        // ball.transform.position = new Vector3(mousePos.x, ball.transform.position.y, ball.transform.position.z);


        // }

        switch (CurrentState)
        {
            case GameState.Idle:
                CurrentState = GameState.Inhand;
                ball.transform.parent = handController;
                ball.transform.localPosition = Vector3.forward;
                //ball.GetComponent<Animator>().enabled = false;
                ball.GetComponent<Rigidbody>().isKinematic = true;



                break;
            case GameState.Inhand:
                float xrot = Mathf.Abs(OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote).x);
                //if (Input.GetKey(KeyCode.S))
                //{
                //    xrot += Time.deltaTime * 5;
                //}

                UIManagers.instance.gearRotationText.text = " Gear Rotation =  [ " + OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote) + " ]";

                if (xrot < 0.7)
                {
                    checkX = true;
                    timer = 0;
                }
                else if (checkX && xrot > 0.2f && timer < 1f)
                {



                    //float force = (1 / timer) * 20;

                    //UIManagers.instance.gearRotationText.text = " Force =  [ " + force + " ]";

                    ball.transform.parent = null;
                    ball.GetComponent<Rigidbody>().isKinematic = false;

                    Vector3 FinalDir = dir + handController.forward;

                    ball.GetComponent<Rigidbody>().AddForce(FinalDir.normalized * 2000);


                    CurrentState = GameState.Shot;
                    //xrot = -1;
                    shotedBall++;
                    totalBalls--;
                    UIManagers.instance.UpdateBallIcons();


                    if (totalBalls <= 0)
                    {
                        //check gameoevr
                        print("Game Over");
                        //StartCoroutine(CheckGameOver());
                        lastShot = true;
                    }

                    checkX = false;
                }
                else if (checkX)
                {
                    timer += Time.deltaTime;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    //shoot the ball
                    ball.transform.parent = null;
                    ball.GetComponent<Rigidbody>().isKinematic = false;

                    ball.GetComponent<Rigidbody>().AddForce(dir.normalized * 2000);
                    CurrentState = GameState.Shot;

                    shotedBall++;
                    totalBalls--;
                    UIManagers.instance.UpdateBallIcons();


                    if (totalBalls <= 0)
                    {
                        //check gameoevr
                        print("Game Over");
                        lastShot = true;

                    }
                }

                //float dist;
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //if (plane.Raycast(ray, out dist))
                //{
                //    Vector3 point = ray.GetPoint(dist);
                //    //Target.position = new Vector3(point.x, point.y, 0);
                //}

                break;
            case GameState.Shot:
                gameTimer += Time.deltaTime;

                if (gameTimer > 3)
                {
                    NextBall();
                }
                break;
            default:
                break;
        }






    }

    private void NextBall()
    {
        if (!lastShot)
        {
            CurrentState = GameState.Idle;
        }
        else
        {
            CurrentState = GameState.gameover;

            UIManagers.instance.gameOverUI.SetActive(true);
            UIManagers.instance.HightScore();

            lastShot = false;
        }
        gameTimer = 0;
    }

    public void GroundFallenCheck()
    {
        if (AllGrounded())
        {
            //Load next Level
            print("Load Next Level");

            LoadNextLevel();

        }

    }

    bool AllGrounded()
    {
        Transform canSet = allLevels[currentLevel].transform;
        foreach (Transform t in canSet)
        {
            if (t.GetComponent<Cans>().hasFallen == false)
            {
                return false;
            }
        }

        return true;
    }

    public void LoadNextLevel()
    {
        if (CurrentState == GameState.Shot || CurrentState == GameState.gameover)
        {
            StartCoroutine(LoadNextLevelRoutine());
            CurrentState = GameState.Idle;

        }
    }
    IEnumerator LoadNextLevelRoutine()
    {
        UIManager.instance.GameUI.SetActive(false);
        UIManagers.instance.YouWin(true);
        Debug.Log("Loding next level");
        yield return new WaitForSeconds(1.5f);
        UIManagers.instance.YouWin(false);
        UIManagers.instance.ShowBlackFade();
        allLevels[currentLevel].SetActive(false);
        currentLevel++;

        if (currentLevel > allLevels.Length) currentLevel = 0;

        yield return new WaitForSeconds(1.0f);
        UIManagers.instance.UpdateScoreMultiplier();

        shotedBall = 0;

        print("current level " + currentLevel);

        allLevels[currentLevel].SetActive(true);
        totalBalls = 5;
        UIManagers.instance.UpdateBallIcons();

        ballScript.RepoitionBall();

        UIManager.instance.GameUI.SetActive(true);

    }
    public void AddExtraBall(int count)
    {
        if (totalBalls < 5)
        {
            totalBalls += count;
            UIManagers.instance.UpdateBallIcons();


        }

    }
    //IEnumerator CheckGameOver()
    //{
    //    yield return new WaitForSeconds(2f);
    //    if (AllGrounded() == false)
    //    {

    //        UIManagers.instance.gameOverUI.SetActive(true);
    //        
    //        CurrentState = GameState.gameover;

    //    }


    //}

}
