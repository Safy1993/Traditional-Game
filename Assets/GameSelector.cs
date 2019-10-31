using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelector : MonoBehaviour
{
    public GameObject MathrabGame;
    public GameObject AmberGame;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("game",0) == 0)
        {
            MathrabGame.SetActive(true);
            AmberGame.SetActive(false);
        }
        else
        {
            MathrabGame.SetActive(false);
            AmberGame.SetActive(true);
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
}
