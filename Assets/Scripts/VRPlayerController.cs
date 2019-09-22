using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerController : MonoBehaviour
{
    public float Speed;
    public Transform centerEye;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touvhInput = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);

        Vector3 forward = centerEye.forward;
        forward.y = 0;
        transform.position += forward * touvhInput.y * Speed * Time.deltaTime;
        Vector3 right = centerEye.forward;
        right.y = 0;
        transform.position += right * touvhInput.x * Speed * Time.deltaTime;


    }
}
