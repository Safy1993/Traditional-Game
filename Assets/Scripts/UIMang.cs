﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMang : MonoBehaviour
{
    public static UIMang instance; 
    public GameObject[] allBallImg;
 


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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBallIcons()
    {
        Debug.Log("UpdateBallIcons");

        int ballCount = LevelManager.Instance.totalBalls;
        Debug.Log("ballCount  : " + ballCount);


        for (int i = 0; i < 5; i++)
        {
           
            if (i < ballCount)
            {
                allBallImg[i].GetComponent<Image>().color = Color.white;
                Debug.Log("white");

            }
            else
            {
                allBallImg[i].GetComponent<Image>().color =Color.gray;
                Debug.Log("gray");
            }


        }

    }
}
