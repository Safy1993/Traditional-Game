using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update


    public void onNextLevel()
    {

        SceneManager.LoadScene("GameL1");

        for (int i = 0; i < LevelManager.Instance.arrowLevel2.Length; i++)
        {
            LevelManager.Instance.arrowLevel2[i].SetActive(true);
        }

        for (int i = 0; i < LevelManager.Instance.arrowLevel1.Length; i++)
        {
            LevelManager.Instance.arrowLevel1[i].SetActive(false);
        }

    }

}
