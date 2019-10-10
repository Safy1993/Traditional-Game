using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    public int totalBalls = 5;

    public static LevelManager Instance;

    int numOfShooting;
    public float timer = 2;
    // Start is called before the first frame update
    void Start()
    {
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
                    //Debug.Log("upArrow KeyDown");
                    Shoot();
                    //numOfShooting--;
                }


               

                break;


            case PutterState.shooting:


                //print("shooting " + ball.velocity.magnitude);

                if (ball.velocity.magnitude >= 0)
                {
                    CurrentState = PutterState.following;
                }


                break;


            case PutterState.following:

                //print("following " + ball.velocity.magnitude);

                if (ball.velocity.magnitude <= 0.05f)
                {
                   // print("following ball.velocity.magnitude < 0 ");
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
}
