using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleControl : MonoBehaviour
{

    float xRotat=-50.0f;

    public Transform ball;
    float ballSpeed = 20.0f;
    Vector3 newPosition;

    float paddleSpeed = 10.0f;

  
    Vector3 lookDirection;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {

       
        lookDirection = ((ball.position - transform.position) - new Vector3(0, 0, 1f)).normalized;

        transform.Translate(lookDirection * Time.deltaTime * paddleSpeed);

        if (Input.GetKeyDown (KeyCode.Space))
        {
            transform.Rotate(xRotat, 0, 0);   
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

       else if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Translate(Vector3.left * paddleSpeed * Time.deltaTime);
            transform.LookAt(ball);

        }


       else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * paddleSpeed * Time.deltaTime);
            transform.LookAt(ball);

        }

      else  if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * paddleSpeed * Time.deltaTime);
            transform.LookAt(ball);

        }

     else   if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * paddleSpeed * Time.deltaTime);
            transform.LookAt(ball);

        }


    } 


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "ball")
        {
        
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * ballSpeed ,ForceMode.Force);
          
        }
      
      
    }
}
