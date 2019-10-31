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

       


        float xrot = wrapAngel(OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote).eulerAngles.x);

        UIMang.instance.gearRotation.text = " Gear Rotation =  [ " + xrot + " ]";

        if (LevelManager.Instance.CurrentState == PutterState.Idle)
        {
            if (xrot > 70)
            {
                checkX = true;
                timer = 0;
            }
            else if (checkX && xrot < 10 && timer < 1f)
            {
                force = (1 / timer) * 200;
                force = Mathf.Clamp(force, 100, 1200);
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

    float wrapAngel(float angel)
    {
        if (angel > 180)
            angel -= 360;

        if (angel < -180)
            angel += 360;

        return angel;
    }
}

