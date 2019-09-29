using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Applies an explosion force to all nearby rigidbodies
public class PutterForce : MonoBehaviour
{
    int numOfShooting;
    public Text numShootingText;
    public int totalBalls = 5;
    public static PutterForce instance;
    public GameObject ball;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.parent.forward * 50);
            numOfShooting++;

            totalBalls--;
            UIMang.instance.UpdateBallIcons();


            if (totalBalls >= 5)
            {
                Destroy(ball);
            }

        }

        Debug.Log(numOfShooting);
        numShootingText.text = "Shooting : " + numOfShooting;

      
    }




}