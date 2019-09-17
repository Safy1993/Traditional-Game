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
            zForce += 50; 
        }

        if (Input.GetKeyDown("x"))
        {
            zForce -= 50;
        }

        if (Input.GetKey("a"))
        {
            transform.Rotate(0,-2,0);
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 2, 0);
        }
    }

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddRelativeForce(0,0, zForce);

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
