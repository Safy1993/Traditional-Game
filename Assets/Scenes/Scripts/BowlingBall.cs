using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float force;
    // Use this for initialization
   
    private Vector3 ballPosition;
    public GameObject ball;
    void Start()
    {
  

        ballPosition = GameObject.FindGameObjectWithTag("Ball").transform.position;
  
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, force));
        if (Input.GetKey(KeyCode.LeftArrow)) { 

        Vector3 addition = Vector3.forward * Time.deltaTime;
        gameObject.transform.position -= addition;
    }
        if (Input.GetKeyUp(KeyCode.RightArrow))
            GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
       
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pin")
        {
            var ball = GameObject.FindGameObjectWithTag("Ball");
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.transform.position = ballPosition;
        }

        
    }
}