using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    public int totalBalls = 10;

    public GameObject[] arrowLevel1 ;

    public GameObject[] arrowLevel2;
    public Button nextLevel; 

    public static LevelManager Instance;

    int numOfShooting;
    public float timer = 2;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < arrowLevel1.Length; i++)
        {
            arrowLevel1[i].SetActive(true);
        }

        for (int i = 0; i < arrowLevel2.Length; i++)
        {
            arrowLevel2[i].SetActive(false);
        }
        nextLevel.enabled = false; 

        Instance = this;

        numOfShooting = 5;
    }

    // Update is called once per frame
    void Update()
    {
      

        print(CurrentState);

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
             
                   timer -= Time.deltaTime;

                    if (timer < 0)
                    {
                       
                        if (totalBalls == 0)
                        {
                            UIMang.instance.ShowGameOver();
                        }
                        else
                        {
                            print("Idel state >>> ");
                            CurrentState = PutterState.Idle;
                            paddle.MovePlayer();
                            timer = 2;
                        }
                    }
                }

                break;

        }


    }

    public void Shoot()
    {
        paddle.Shoot();
        CurrentState = PutterState.shooting;
    }

    public void onNextLevel()
    {

        SceneManager.LoadScene("GameL1");
        
        for (int i = 0; i < arrowLevel2.Length; i++)
        {
            arrowLevel2[i].SetActive(true);
        }

        for (int i = 0; i < arrowLevel1.Length; i++)
        {
            arrowLevel1[i].SetActive(false);
        }

    }
}
