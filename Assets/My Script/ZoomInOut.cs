using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    public float zoomSpeed;
    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {

        if (Input.touchCount == 2)
        {

            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);


            Vector2 touch1Direction = touch1.position - touch1.deltaPosition;
            Vector2 touch2Direction = touch2.position - touch2.deltaPosition;

            float distancePosition = Vector2.Distance(touch1.position, touch2.position);
            float distanceDirection = Vector2.Distance(touch1Direction, touch2Direction);


            float zoom = distanceDirection - distancePosition;

            cam.fieldOfView += zoom * zoomSpeed;

            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 10f, 85f);


        }
    }
}
