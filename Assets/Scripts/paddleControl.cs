using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleControl : MonoBehaviour
{

    float xRotat;

    public Transform ball;
  
    float zForce;
    Vector3 newPosition;

    float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKeyDown (KeyCode.Space))
        {

            xRotat = -36;
            transform.Rotate(xRotat, 0, 0);
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
           
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.LookAt(ball.position);
            //if ((transform.position - ball.position).magnitude > 0.1f)
            //{
                transform.Translate(0, 0, speed * Time.deltaTime);
            //}
        }



     

       

        
    } 


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "ball")
        {
            zForce = 100;
            ball.GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce);

          


        }
      
        zForce = 0;
    }
}
