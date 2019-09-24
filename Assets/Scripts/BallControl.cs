using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{

    public GameObject WinText; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "hole")
        {

            Debug.Log("  hole ");
            WinText.SetActive(true);

        }

    }





}
