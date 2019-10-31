/************************************************************************************

Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.  

See SampleFramework license.txt for license terms.  Unless required by applicable law 
or agreed to in writing, the sample code is provided “AS IS” WITHOUT WARRANTIES OR 
CONDITIONS OF ANY KIND, either express or implied.  See the license for specific 
language governing permissions and limitations under the license.

************************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class HandedInputSelector : MonoBehaviour
{
    public OVRCameraRig m_CameraRig_M;
    //public OVRInputModule m_InputModule_M;

    public OVRCameraRig m_CameraRig_A;
    //public OVRInputModule m_InputModule_A;

    OVRCameraRig m_CameraRig;
    OVRInputModule m_InputModule;

    void Start()
    {
        if (PlayerPrefs.GetInt("game", 0) == 0)
        {
            m_CameraRig = m_CameraRig_M;// = FindObjectOfType<OVRCameraRig>();
            //m_InputModule = m_InputModule_M;//= FindObjectOfType<OVRInputModule>();
        }
        else
        {
            m_CameraRig = m_CameraRig_A;// = FindObjectOfType<OVRCameraRig>();
           
        }

        m_InputModule =  FindObjectOfType<OVRInputModule>();
    }

    void Update()
    {
        if(OVRInput.GetActiveController() == OVRInput.Controller.LTouch)
        {
            SetActiveController(OVRInput.Controller.LTouch);
        }
        else
        {
            SetActiveController(OVRInput.Controller.RTouch);
        }

    }

    void SetActiveController(OVRInput.Controller c)
    {
        Transform t;
        if(c == OVRInput.Controller.LTouch)
        {
            t = m_CameraRig.leftHandAnchor;
        }
        else
        {
            t = m_CameraRig.rightHandAnchor;
        }
        m_InputModule.rayTransform = t;
    }
}
