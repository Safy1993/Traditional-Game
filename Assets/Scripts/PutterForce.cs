using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Applies an explosion force to all nearby rigidbodies
public class PutterForce : MonoBehaviour
{
    public GameObject ball;
    public float ballforce=50;
     

   

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ballforce += 50;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ballforce -= 50;
        }


       
    }


        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
          
            other.GetComponent<Rigidbody>().AddForce(transform.parent.forward * ballforce);
          
            LevelManager.Instance.totalBalls--;
         
            UIMang.instance.UpdateBallIcons();


        }

    }





}