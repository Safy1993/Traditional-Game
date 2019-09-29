﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PutterState
{ Idle,
  shooting,
  following
}



public class LevelManager : MonoBehaviour
{
    PutterState CurrentState;
    public paddleControl paddle;
    public Rigidbody ball;
    public int totalBalls = 5;

    public static LevelManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        switch (CurrentState)
        {

            case PutterState.Idle:

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("upArrow KeyDown");
                    paddle.Shoot();

                    CurrentState = PutterState.shooting;
                }
                break;

            case PutterState.shooting:


                if (ball.velocity.magnitude > 0)
                {
                    CurrentState = PutterState.following;
                }
     

                break;

            case PutterState.following:

                if (ball.velocity.magnitude == 0)
                {
                    CurrentState = PutterState.Idle;

                }


                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    paddle.MovePlayer();
                }

                    break;

        }


    }
}
