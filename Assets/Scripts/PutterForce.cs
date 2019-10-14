using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Applies an explosion force to all nearby rigidbodies
public class PutterForce : MonoBehaviour
{
 
    public float ballforce;


       public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            print("ball");
           ballforce= GearController.Instance.force;
           other.GetComponent<Rigidbody>().AddForce(transform.parent.forward * 70);
          
            LevelManager.Instance.totalBalls--;
         
            UIMang.instance.UpdateBallIcons();


        }

    }





}