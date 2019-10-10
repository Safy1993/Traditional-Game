using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 offset;

    public float Speed;

    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 TargetPosition = Target.position + Vector3.up * offset.y + Vector3.forward * offset.x;


        Vector3 TargetVector = TargetPosition - transform.position;

        Vector3 direction = TargetVector.normalized;

        transform.position += direction * Speed * Time.deltaTime * Mathf.Min(5, TargetVector.magnitude);

        transform.LookAt(Target);

    }
}
