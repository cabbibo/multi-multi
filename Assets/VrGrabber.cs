using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;
using Normal.Realtime;



public class VrGrabber : Grabber
{
    public Human human;
    public bool right;

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

    public override void WhileGrabbing(){
        insideTransform.position = transform.position;
        insideTransform.rotation = transform.rotation;
    }


    public override void CheckForGrab(){
            
            float tVal = human.LeftTrigger;
            float otVal = human.oLeftTrigger;
            if( right ){ tVal = human.RightTrigger; otVal = human.oRightTrigger; }

            if( otVal < .5f &&  tVal >= .5f && inside  ){ 

                _OnGrab();
            } 

            if( otVal >= .5f &&  tVal < .5f ){

                _OnRelease();
            }
    }

    public override void OnRelease(){
        if( makeKinematic ) insideRigidbody.velocity = -(insideTransform.position-transform.position) / Time.deltaTime;

        if( inside == false ){
            insideTransform = null;
            insideRealtime = null;
            insideRigidbody = null;
        }
    }

}
