using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation3D : MonoBehaviour
{
    private Touch touch;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    
    private Vector3 previousPosition;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                previousPosition = cam.ScreenToViewportPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 newPosition = cam.ScreenToViewportPoint(touch.position);
                Vector3 direction = previousPosition - newPosition;
                
                float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
                float rotationAroundXAxis = direction.y * 180; // camera moves vertically


                cam.transform.position = new Vector3(0,1,0);

                rotationAroundXAxis = Mathf.Clamp(rotationAroundXAxis, -1, 1);

                cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

                cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

                previousPosition = newPosition;
            }
        }
    }
}

