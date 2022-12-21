using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation3D : MonoBehaviour
{

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
                    -touch.deltaPosition.x * rotateSpeedModifier,
                    0f);
                transform.rotation = rotationY * transform.rotation;
            }
        }
    }

}

    