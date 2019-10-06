using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    float timer= Time.deltaTime; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion posetion = OVRInpu

        UIMang.instance.gearRotation.text = " Gear Rotation =  [ " +  OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote) + " ]";

        
    }
}
