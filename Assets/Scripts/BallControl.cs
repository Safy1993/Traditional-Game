using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{


    public int totalScore; 

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "hole")
        {

            print(">>> hole");

            UIMang.instance.endText.text = "you are win";
            UIMang.instance.endText.enabled = true;
         

            PlayerPrefs.SetInt("Score", UIMang.instance.score);

            LevelManager.Instance.nextLevel.SetActive(true);


            for (int i = 0; i < LevelManager.Instance.arrowLevel1.Length; i++)
            {
                LevelManager.Instance.arrowLevel1[i].SetActive(false);
            }



        }

        if (other.gameObject.tag == "holeL2")
        {

        

            UIMang.instance.endText.text = "you are win Level 2";
            UIMang.instance.endText.enabled = true;


            // UIMang.instance.WinText.SetActive(true);

           // LevelManager.Instance.nextLevel.enabled = true;
            //for (int i = 0; i < LevelManager.Instance.arrowLevel1.Length; i++)
            //{
            //    LevelManager.Instance.arrowLevel1[i].SetActive(false);
            //}



        }

    }
}
