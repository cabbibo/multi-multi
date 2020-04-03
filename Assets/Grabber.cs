using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;
using Normal.Realtime;



public class Grabber : MonoBehaviour
{
    public Human human;
    public bool right;

    public bool grabbing;
    public Transform insideTransform;
    public RealtimeTransform insideRealtime;
    public RealtimeView insideView;
    public Rigidbody insideRigidbody;

    public string tagToGrab = "Moveable";
    public bool makeKinematic;
    public bool inside;



    public void OnTriggerEnter(Collider c){
        if(c.tag == tagToGrab){
            if( insideTransform == null && grabbing == false ){
                insideTransform = c.transform;
                insideRealtime = c.GetComponent<RealtimeTransform>();
                insideRigidbody = c.GetComponent<Rigidbody>();
                insideView = c.GetComponent<RealtimeView>();
                inside = true;
            }
        }
    }

    public void OnTriggerExit( Collider c ){
        if( c != null){
            if(c.transform == insideTransform){
                inside = false;

                // cant let go if we are a force based interaction
                if( grabbing == false || makeKinematic ){
                    insideTransform = null;
                    insideRealtime = null;
                    insideRigidbody = null;
                    insideView = null;
                }
            }
        }

    }

    public virtual void WhileGrabbing(){
        insideTransform.position = transform.position;
        insideTransform.rotation = transform.rotation;
    }
    public virtual void OnRelease(){
    }
    public virtual void OnGrab(){

    }

    public void Update(){

        if( human.view.isOwnedLocally  && insideTransform != null && insideView != null && insideRigidbody != null && insideRealtime != null){

            float tVal = human.LeftTrigger;
            float otVal = human.oLeftTrigger;
            if( right ){ tVal = human.RightTrigger; otVal = human.oRightTrigger; }

            if( otVal < .5f &&  tVal >= .5f ){ 
                grabbing = true;
                insideRigidbody.isKinematic = makeKinematic;
                insideRealtime.RequestOwnership();
                insideView.RequestOwnership();
            } 

            if( otVal >= .5f &&  tVal < .5f ){
                grabbing = false; 
                insideRigidbody.isKinematic = false;
                if( makeKinematic ) insideRigidbody.velocity = -(insideTransform.position-transform.position) / Time.deltaTime;

                if( inside == false ){
                    insideTransform = null;
                    insideRealtime = null;
                    insideRigidbody = null;
                }

                
                OnRelease();
            }
        }

        if( grabbing ){
            if( insideRealtime  != null ){
                if( insideRealtime.isOwnedLocally ){
                    WhileGrabbing();
                }
            }
        }

    }
}
