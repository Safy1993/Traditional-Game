using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleControl : MonoBehaviour
{

    float yRotat;

    public Transform ball;

    float zForce; 

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {

            yRotat = -36;
            transform.Rotate(yRotat, 0, 0); 
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            yRotat = 36;
            transform.Rotate(yRotat, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-0.5f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(0.5f, 0,0 );
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate( 0,0, 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, 0,- 0.5f);
        }
    } 


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "ball")
        {
            zForce = 10;
            ball.GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce);
        }

        zForce = 0;
    }
}
