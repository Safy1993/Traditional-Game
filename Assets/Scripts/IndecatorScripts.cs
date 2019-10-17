using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndecatorScripts : MonoBehaviour
{

    Vector3 startPosition;

    Vector3 endPosition;
    Camera cameraL;
    LineRenderer lineRenderer;
    Vector3 camOffeset = new Vector3(0, 0, 10);
    [SerializeField] AnimationCurve animationCurve;
      
    // Start is called before the first frame update
    void Start()
    {
        cameraL = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (lineRenderer== null)
            {
                lineRenderer = gameObject.AddComponent<LineRenderer>();
            }
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
            startPosition = cameraL.ScreenToWorldPoint(Input.mousePosition) + camOffeset;
            lineRenderer.SetPosition(0,startPosition);
            lineRenderer.useWorldSpace = true;
            lineRenderer.widthCurve = animationCurve;
            lineRenderer.numCapVertices = 10;

        }

        if (Input.GetMouseButton(0))
        {
            endPosition= cameraL.ScreenToWorldPoint(Input.mousePosition) + camOffeset;
            lineRenderer.SetPosition(1, endPosition);
        }


        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;

        }
    }
}
