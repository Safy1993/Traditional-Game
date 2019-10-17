using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{

    public GameObject WinText; 


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "hole")
        {

            print(">>> hole");

            UIMang.instance.endText.text = "you are win";
            UIMang.instance.endText.enabled = true;
            UIMang.instance.WinText.SetActive(true);

            for (int i = 0; i < LevelManager.Instance.arrowLevel1.Length; i++)
            {
                LevelManager.Instance.arrowLevel1[i].SetActive(false);
            }



        }

    }
}
