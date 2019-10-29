using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{


    public int totalScore;

    new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //print(rigidbody.velocity.magnitude);
        //if (rigidbody.velocity.magnitude < 0.7f)
        if (LevelManager.Instance.CurrentState == PutterState.following)
        {
            print(rigidbody.velocity.magnitude);

            if (rigidbody.velocity.magnitude < 1f)
                rigidbody.velocity -= rigidbody.velocity * 0.05f;
           
            //print((10 - rigidbody.velocity.magnitude) * 0.01f);
            //rigidbody.velocity -= rigidbody.velocity * (10 - rigidbody.velocity.magnitude) * 0.005f; //(1 / (rigidbody.velocity.magnitude * 200));
        }
        else if (LevelManager.Instance.CurrentState == PutterState.Idle)
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "hole")
        {
            print(">>> hole");
            LevelManager.Instance.FinishedLevel();

        }
    }
}
