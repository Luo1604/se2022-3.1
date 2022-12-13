using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation3D : MonoBehaviour
{
<<<<<<< HEAD

    private Touch touch;
    private Quaternion rotationY;
=======
    // Vector3 mPrevPos = Vector3.zero;
    // Vector3 mPosDelta = Vector3.zero;
>>>>>>> 69cfd30cab42c8bfee883424cf3a6ae859f9f0f0


    private float rotateSpeedModifier = 0.1f;

<<<<<<< HEAD
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(
                    touch.deltaPosition.y * rotateSpeedModifier,
                    -touch.deltaPosition.x * rotateSpeedModifier,
                    0f);

=======
    // //Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetMouseButton(0)) {
    //         mPosDelta=Input.mousePosition-mPrevPos;

    //         //Vecto3.up : Vecto3(0,1,0)
    //         //Vecto3.Dot() : tra ve tich vo huong 2 vecto
    //         if(Vector3.Dot(transform.up, Vector3.up) >= 0) {
    //             transform.Rotate(transform.up, -Vector3.Dot(mPosDelta,Camera.main.transform.right), Space.World);
    //     //     } else {
    //     //         transform.Rotate(transform.up, Vector3.Dot(mPosDelta,Camera.main.transform.right), Space.World);
    //     //     }
    //     //     transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
    //     // }
    //         }
    //     }
    //     mPrevPos = Input.mousePosition;
    // }

    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationY;


    private float rotateSpeedModifier = 0.1f;

    void Update() {
        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved) {
                rotationY = Quaternion.Euler(
                    touch.deltaPosition.y * rotateSpeedModifier,
                    - touch.deltaPosition.x * rotateSpeedModifier,
                    0f);
                
>>>>>>> 69cfd30cab42c8bfee883424cf3a6ae859f9f0f0
                transform.rotation = rotationY * transform.rotation;
            }
        }
    }
}
