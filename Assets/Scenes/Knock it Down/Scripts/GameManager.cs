using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum GameState
{
    Idle,
    Inhand,
    Shot,
    ballMoving
}


public class GameManager : MonoBehaviour
{
    public GameState CurrentState;

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

    bool checkX;
    float timer;

    float gameTimer = 0;

    public Transform handController;
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

        switch (CurrentState)
        {
            case GameState.Idle:
                CurrentState = GameState.Inhand;
                break;
            case GameState.Inhand:
                float xrot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote).x;

                if (xrot < -0.3)
                {
                    checkX = true;
                    timer = 0;
                }
                else if (checkX && xrot > 0.3 && timer < 1f)
                {
                    float force = (1 / timer) * 15;

                    ball.GetComponent<Rigidbody>().AddForce(-handController.up * force);

                    CurrentState = GameState.Shot;
                    //force = 70;
                    //LevelManager.Instance.Shoot();
                    checkX = false;
                }
                else if (checkX)
                {
                    timer += Time.deltaTime;
                }

                if (Input.GetMouseButtonUp(0) && readyToShoot)
                {
                    //shoot the ball
                    ball.GetComponent<Rigidbody>().AddForce(dir * ballForce, ForceMode.Impulse);
                    CurrentState = GameState.Shot;
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

                break;
            case GameState.Shot:
                gameTimer += Time.deltaTime;

                if (gameTimer > 3)
                {
                    CurrentState = GameState.Idle;
                    gameTimer = 0;
                }
                break;
            default:
                break;
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
        if (CurrentState == GameState.Shot)
        {
            StartCoroutine(LoadNextLevelRoutine());
            CurrentState = GameState.Idle;

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

        print("current level " + currentLevel);

        allLevels[currentLevel].SetActive(true);
        totalBalls = 5;
        UIManager.instance.UpdateBallIcons();
       
        ballScript.RepoitionBall();

        gameHasStarted = true;

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
           
            UIManager.instance.gameOverUI.SetActive(true);
            UIManager.instance.HightScore();


        }


    }

}
