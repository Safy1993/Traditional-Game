using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelector : MonoBehaviour
{
    public GameObject MainMenuPref;
    public GameObject MathrabGame;
    public GameObject AmberGame;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("game", 0) == 0)
        {
            MainMenuPref.SetActive(true);
            MathrabGame.SetActive(false);
            AmberGame.SetActive(false);
        }
       else if (PlayerPrefs.GetInt("game", 1) == 1)
        {
            MathrabGame.SetActive(true);
            AmberGame.SetActive(false);
            MainMenuPref.SetActive(false);
        }
        else
        {
            MathrabGame.SetActive(false);
            AmberGame.SetActive(true);
            MainMenuPref.SetActive(false);
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
