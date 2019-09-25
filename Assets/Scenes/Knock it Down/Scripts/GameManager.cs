using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ball;
    Plane plane = new Plane(Vector3.forward,0);
    public Transform Target;
    public float ballForce;
    public bool readyToShoot;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance=null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Target.position - ball.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,5));
        

        if (Input.GetMouseButton(0) && readyToShoot)
        {
            //shoot the ball
            ball.GetComponent<Animator>().enabled=false;
            ball.transform.position = new Vector3(mousePos.x, ball.transform.position.y, ball.transform.position.z);
            

        }

        if (Input.GetMouseButtonUp(0) && readyToShoot)
        {
            //shoot the ball
            ball.GetComponent<Rigidbody>().AddForce(dir* ballForce, ForceMode.Impulse);
        }
        float dist;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(plane.Raycast (ray,out dist))
        {
            Vector3 point = ray.GetPoint(dist);
            Target.position = new Vector3(point.x, point.y, 0);
        }
        
    }
}
