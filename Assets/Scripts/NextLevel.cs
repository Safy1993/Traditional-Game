using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            onNextLevel();
        }
    }
    public void onNextLevel()
    {

        SceneManager.LoadScene("GameL1");

        LevelManager.Instance.containerL1.SetActive(true);
        LevelManager.Instance.containerL2.SetActive(false);


        for (int i = 0; i < LevelManager.Instance.arrowLevel2.Length; i++)
        {
            LevelManager.Instance.arrowLevel2[i].SetActive(true);
        }

        for (int i = 0; i < LevelManager.Instance.arrowLevel1.Length; i++)
        {
            LevelManager.Instance.arrowLevel1[i].SetActive(false);
        }

    }


    public void backtomainmenue()
    {
        SceneManager.LoadScene("MainMnue");
    }

}
