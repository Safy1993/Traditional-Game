using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Applies an explosion force to all nearby rigidbodies
public class PutterForce : MonoBehaviour
{
    int numOfShooting;
    public Text numShootingText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.parent.forward * 50);
            numOfShooting++; 

        }

        Debug.Log(numOfShooting);
        numShootingText.text = "Shooting : " + numOfShooting;
     

    }




}