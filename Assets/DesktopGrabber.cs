using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;
using Normal.Realtime;



public class DesktopGrabber : Grabber
{
    public DesktopAvatarValueSetter avatar;
    public float grabDist;


    public override void WhileGrabbing(){

        print("helllslsoosoos");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 pos = ray.origin + ray.direction * grabDist;
        insideTransform.position = pos;
        insideTransform.rotation = transform.rotation;
    }

    public override void OnRelease(){
        insideRigidbody = null;
        insideView = null;
        insideRealtime = null;
        insideTransform = null;
    }

    public override void OnGrab(){

    }

    public virtual void OnUp(){
        if( grabbing ) _OnRelease();
    }

    public virtual void OnDown(){

        RaycastHit hit;
        if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition) , out hit)) {

            if( hit.collider.tag == tagToGrab ){

                right = 1;
            
                grabDist = hit.distance;

                insideRealtime = hit.collider.gameObject.GetComponent<RealtimeTransform>();
                insideView = hit.collider.gameObject.GetComponent<RealtimeView>();
                insideRigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                grabbedGrabbable = hit.collider.gameObject.GetComponent<Grabbable>();
                insideTransform = hit.collider.transform;   
                _OnGrab();

            }
            
        }
    }

    public override void CheckForGrab(){
    
        if( Input.GetMouseButtonDown(0) ){
            print("OnDown");
            OnDown();
        }

        if( Input.GetMouseButtonUp( 0 ) ){
            OnUp();
        }

    }


}
