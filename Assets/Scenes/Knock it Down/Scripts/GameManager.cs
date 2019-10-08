using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ball;
    Plane plane = new Plane(Vector3.forward, 0);
    public Transform Target;
    public float ballForce;
    public bool readyToShoot;
    public int totalBalls;
    public int currentLevel;
    public GameObject[] allLevels;
    public GameObject[] casSetGRB;

    public Ball ballScript;
    public bool gameHasStarted;

    public int shotedBall;
 


    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }

    }

    void Start()
    {
       

    }
    public void StartGame()
    {
        gameHasStarted = true;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;

        }
        Vector3 dir = Target.position - ball.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));


        if (Input.GetMouseButton(0) && readyToShoot)
        {
            //shoot the ball
            ball.GetComponent<Animator>().enabled = false;
            ball.transform.position = new Vector3(mousePos.x, ball.transform.position.y, ball.transform.position.z);


        }

        if (Input.GetMouseButtonUp(0) && readyToShoot)
        {
            //shoot the ball
            ball.GetComponent<Rigidbody>().AddForce(dir * ballForce, ForceMode.Impulse);
            readyToShoot = false;
            shotedBall++;
            totalBalls--;
            UIManager.instance.UpdateBallIcons();
                
                
            if (totalBalls <= 0)
            {
                //check gameoevr
                print("Game Over");
                StartCoroutine(CheckGameOver());

            }
        }

        float dist;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out dist))
        {
            Vector3 point = ray.GetPoint(dist);
            Target.position = new Vector3(point.x, point.y, 0);
        }

    }
    public void GroundFallenCheck()
    {
        if (AllGrounded())
        {
            //Load next Level
            print("Load Next Level");
            LoadNextLevel();

        }

    }

    bool AllGrounded()
    {
        Transform canSet = allLevels[currentLevel].transform;
        foreach (Transform t in canSet)
        {
            if (t.GetComponent<Can>().hasFallen == false)
            {
                return false;
            }
        }

        return true;
    }

    public void LoadNextLevel()
    {
        if (gameHasStarted)
        {
            StartCoroutine(LoadNextLevelRoutine());

        }
    }
    IEnumerator LoadNextLevelRoutine()
    {
        Debug.Log("Loding next level");
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.ShowBlackFade();
        readyToShoot = false;
        allLevels[currentLevel].SetActive(false);
        currentLevel++;

        if (currentLevel > allLevels.Length) currentLevel = 0;
        yield return new WaitForSeconds(1.0f);
        UIManager.instance.UpdateScoreMultiplier();
        shotedBall = 0;
        allLevels[currentLevel].SetActive(true);
        UIManager.instance.UpdateBallIcons();
        ballScript.RepoitionBall();


    }
    public void AddExtraBall(int count)
    {
        if (totalBalls<5)
        {
            totalBalls += count;
            UIManager.instance.UpdateBallIcons();


        }

    }
    IEnumerator CheckGameOver()
    {
       yield return new WaitForSeconds(2f);
        if (AllGrounded()==false)
        {
           UIManager.instance.HightScore();
            UIManager.instance.gameOverUI.SetActive(true);
           

        }


    }

}
