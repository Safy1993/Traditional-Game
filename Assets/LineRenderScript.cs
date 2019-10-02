using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderScript : MonoBehaviour
{

    LineRenderer lineRenderer;
    Vector3 finalTouchPosition;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startColor=Color.blue;
        lineRenderer.endColor = Color.green;
       

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        lineRenderer.SetPosition(0, ray.origin);


        if (Physics.Raycast(ray, out hit))
        {
            lineRenderer.SetPosition(1, hit.point);

        }

       
    }
}
