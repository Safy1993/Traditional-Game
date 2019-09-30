using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Applies an explosion force to all nearby rigidbodies
public class PutterForce : MonoBehaviour
{
    int numOfShooting;
    public Text numShootingText;
    public GameObject GameOverText;
    public GameObject ball;

    //private void Awake()
    //{
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            Debug.Log("Colliding happen");

            
            
            //2
            other.GetComponent<Rigidbody>().AddForce(transform.parent.forward * 70);
            
            //3
            numOfShooting ++;
            Debug.Log("shooting : "+numOfShooting);
           
            //4
            showShooting();

            //1
            LevelManager.Instance.totalBalls--;
            Debug.Log("total ball  : " + LevelManager.Instance.totalBalls);
            //5 
            UIMang.instance.UpdateBallIcons();


            if (numOfShooting > 5)
            {
                GameOverText.SetActive(true);
              
            }

        }

    }


    public void showShooting()
    {

        numShootingText.text = "Shooting : " + numOfShooting;
        Debug.Log("showShooting method in text  " + numOfShooting);


    }



}