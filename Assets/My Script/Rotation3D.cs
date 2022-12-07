using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation3D : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;



    //Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            mPosDelta=Input.mousePosition-mPrevPos;

            //Vecto3.up : Vecto3(0,1,0)
            //Vecto3.Dot() : tra ve tich vo huong 2 vecto
            if(Vector3.Dot(transform.up, Vector3.up) >= 0) {
                transform.Rotate(transform.up, -Vector3.Dot(mPosDelta,Camera.main.transform.right), Space.World);
        //     } else {
        //         transform.Rotate(transform.up, Vector3.Dot(mPosDelta,Camera.main.transform.right), Space.World);
        //     }
        //     transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
        // }
            }
        }
        mPrevPos = Input.mousePosition;
    }

}
