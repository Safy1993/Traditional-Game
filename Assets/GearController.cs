using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    float timer;
    bool checkX;
    public float force;

 


    public static GearController Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion posetion = OVRInpu

        UIMang.instance.gearRotation.text = " Gear Rotation =  [ " + OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote) + " ]";


        float xrot =  OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote). x;

        if (LevelManager.Instance.CurrentState == PutterState.Idle)
        {
            if (xrot < -0.3)
            {
                checkX = true;
                timer = 0;
            }
            else if (checkX && xrot > 0.3 && timer < 1f)
            {
                force = (1 / timer) * 20;
                //force = 70;
                LevelManager.Instance.Shoot();
                checkX = false;
            }
            else if (checkX)
            {
                timer += Time.deltaTime;
            }
    }
}
}

