using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        switch (CurrentState)
        {

            case PutterState.Idle:


                break;

            case PutterState.shooting:


                break;

            case PutterState.following:


                break;

        }


    }
}
