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

   public void Update(){


           if( Input.GetMouseButtonDown(1)){
               OnMouseDown();
           }

            if( Input.GetMouseButtonUp(1)){
               OnMouseUp();
           }
        if( down ){
            oPos = pos;
            pos =  Input.mousePosition;
            delta = pos - oPos;

            controls.mainAngleVel += delta.x * .0003f;
        }


        
        controls.radiusVel += Input.GetAxis("Mouse ScrollWheel");
   }

   public void OnMouseDown(){
       down = true;
       oPos = Input.mousePosition;
       pos = Input.mousePosition;
   }

   public void OnMouseUp(){
       down = false;
   }
}
