using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDesktopCamera : MonoBehaviour
{

    public DesktopControls controls;


    private Vector3 delta;
    private Vector3 oPos;
    private Vector3 pos;

    public bool down;


    public float oScrollPos;
    public float scrollPos;
    public float scrollDelta;

    public bool mine;

   public void Update(){


       

       if( mine ){
        if( down ){
            print("hiiii");
            oPos = pos;
            pos =  Input.mousePosition;
            delta = pos - oPos;

            controls.mainAngleVel += delta.x * .0003f;
        }


        
        controls.radiusVel += Input.GetAxis("Mouse ScrollWheel");
       }
   }

   public void OnMouseDown(){
       print("hmmmm");
       down = true;
       oPos = Input.mousePosition;
       pos = Input.mousePosition;
   }

   public void OnMouseUp(){
       print("hmmmm1");
       down = false;
   }
}
