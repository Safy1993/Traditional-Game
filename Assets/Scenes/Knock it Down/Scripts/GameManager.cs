using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    Plane plane = new Plane(Vector3.forward,0);
    public Transform Target;
    public float ballForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Target.position - ball.transform.position;

        if (Input.GetMouseButtonDown(0))
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
