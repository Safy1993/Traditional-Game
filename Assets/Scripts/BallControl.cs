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

            Debug.Log("  hole ");
            UIMang.instance.WinText.SetActive(true);

        }

    }
}
