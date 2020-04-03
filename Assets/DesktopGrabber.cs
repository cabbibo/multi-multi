using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;
using Normal.Realtime;



public class DesktopGrabber : MonoBehaviour
{
    public RealtimeView view;
    public DesktopAvatarValueSetter avatar;

    public bool grabbing;
    public Transform insideTransform;
    public RealtimeTransform insideRealtime;
    public RealtimeView insideView;
    public Rigidbody insideRigidbody;

    public string tagToGrab = "Moveable";
    public bool makeKinematic;
    public bool inside;

    public float grabDist;



    public virtual void WhileGrabbing(){
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        Vector3 pos = ray.origin + ray.direction * grabDist;
        insideTransform.position = pos;
        insideTransform.rotation = transform.rotation;
    }
    public virtual void OnRelease(){
    }
    public virtual void OnGrab(){

    }

    public virtual void OnUp(){
        grabbing = false;
        insideRigidbody = null;
        insideView = null;
        insideRealtime = null;
        insideTransform = null;
    }

    public virtual void OnDown(){
        RaycastHit hit;
        if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition) , out hit)) {

            print("raycastHit");
            print( hit.collider.tag );
             if( hit.collider.tag == tagToGrab ){
                
                print("I AM GRABBING");
                print( hit.distance );
                grabbing = true;
                grabDist = hit.distance;

                insideRealtime = hit.collider.gameObject.GetComponent<RealtimeTransform>();
                insideView = hit.collider.gameObject.GetComponent<RealtimeView>();
                insideRigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                insideTransform = hit.collider.transform;

                insideRigidbody.isKinematic = makeKinematic;
                insideRealtime.RequestOwnership();
                insideView.RequestOwnership();
             }

            
        }
    }

    public void Update(){


        if( view.isOwnedLocally ){


            if( Input.GetMouseButtonDown(0) ){
                print("OnDown");
                OnDown();
            }

            if( Input.GetMouseButtonUp( 0 ) ){
                OnUp();
            }


            if( grabbing ){
                WhileGrabbing();
            }

        }

    }
}
