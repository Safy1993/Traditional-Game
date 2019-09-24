using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorFollow : MonoBehaviour
{
    public Transform target;
    Vector3 lookDirection;
    float speed = 10.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        lookDirection = ((target.position - transform.position) - new Vector3(0,0,1)).normalized;
        transform.Translate(lookDirection * Time.deltaTime * speed ); 
    }
}
