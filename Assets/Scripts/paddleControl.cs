using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleControl : MonoBehaviour
{

    float xRotat = -25.0f;

    public Transform ball;
    float ballSpeed = 20.0f;
    Vector3 newPosition;

    float paddleSpeed = 10.0f;
    public Transform putterForward;

    Vector3 lookDirection;


    // Start is called before the first frame update
    void Start()
    {
        // lookDirection = ((ball.position - transform.position) - new Vector3(2, 2, 1f)).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.GetChild(0).Rotate(xRotat, 0, 0,Space.Self);
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, Time.deltaTime * 90, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, -Time.deltaTime * 90, 0);
        }





    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "ball")
    //    {

    //        ball.GetComponent<Rigidbody>().AddForce(transform.forward * ballSpeed, ForceMode.Impulse);
    //        //transform.Translate(lookDirection);
    //    }
    //}



}

