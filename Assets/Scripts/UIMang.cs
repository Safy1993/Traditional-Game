using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMang : MonoBehaviour
{
    public static UIMang instance; 
    public GameObject[] allBallImg;
   // public Sprite enabledBallImg;
   // public Sprite diabledBallImg;


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
        int ballCount = PutterForce.instance.totalBalls;

        for (int i = 0; i < 5; i++)
        {
            if (i < ballCount)
            {
                allBallImg[i].GetComponent<Image>().color = Color.white;
            }
            else
            {
                allBallImg[i].GetComponent<Image>().color =Color.gray ;
            }
        }
    }



}
