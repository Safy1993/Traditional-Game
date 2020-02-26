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
            Instantiate(MathrabGame);
        }
        else
        {
            Instantiate(AmberGame);
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
