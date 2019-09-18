using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrPlayerController : MonoBehaviour
{
    public float speed;

    public Transform CenterEye;

    void Start()
    {

    }

    void Update()
    {

        Vector2 touchInput = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);

        Vector3 direction = CenterEye.forward;
        direction.y = 0;
        Vector3 directionRight = CenterEye.forward;
        directionRight.y = 0;
        transform.position += direction * touchInput.y * speed * Time.deltaTime;


        transform.position += directionRight * touchInput.x * speed * Time.deltaTime;

    }

}