using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutterControl : MonoBehaviour
{

    float xRotat = -25.0f;



    Vector3 newPosition;


    public Transform ballpos;

    public static PutterControl Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;  
    }

    // Update is called once per frame
    void FixedUpdate()
    {

            if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, Time.deltaTime * 90, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            
            transform.Rotate(0, -Time.deltaTime * 90, 0);
        }
 
    }

    public void Shoot()
    {
        transform.GetChild(0).Rotate(xRotat, 0, 0, Space.Self);
    }

    public void MovePlayer()
    {
        print("MovePlayer");
        transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 0);
        transform.position = ballpos.position;
    }

   
}

