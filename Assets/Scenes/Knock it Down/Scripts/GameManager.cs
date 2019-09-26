using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject[] casSetGRB;
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
        readyToShoot = true;

    }

    // Update is called once per frame
    void Update()
    {
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
            totalBalls--;
            if (totalBalls <= 0)
            {
                //check gameoevr
                print("Game Over");

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

        }

    }

    public bool AllGrounded()
    {
        Transform currentSet = casSetGRB[currentLevel].transform;
        foreach(Transform t in currentSet)
        {
            if (t.GetComponent<Can>().hasFallen==false)
            {
                return false;
            }
        
        }
         return true;
    }

}
