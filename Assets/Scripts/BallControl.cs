using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float zForce = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            zForce += 100; 
        }

        if (Input.GetKeyDown("x"))
        {
            zForce += 10;
        }
    }

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddRelativeForce(0,0, zForce);

    }
}
