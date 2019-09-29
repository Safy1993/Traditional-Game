using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Applies an explosion force to all nearby rigidbodies
public class PutterForce : MonoBehaviour
{
    int numOfShooting;
    public Text numShootingText;
    public Text GameOverText;
    public GameObject ball;

    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.parent.forward * 70);

            numOfShooting++;


            LevelManager.Instance.totalBalls--;
            UIMang.instance.UpdateBallIcons();


            if (numOfShooting > 5)
            {
                GameOverText.text = "Game Over";
                GameOverText.enabled = true; 


            }

        }

        Debug.Log(numOfShooting);
        numShootingText.text = "Shooting : " + numOfShooting;

      
    }




}