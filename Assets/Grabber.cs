using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;
using Normal.Realtime;



public class Grabber : MonoBehaviour
{
    public RealtimeView view;

    public bool grabbing;
    public Transform insideTransform;
    public RealtimeTransform insideRealtime;
    public RealtimeView insideView;
    public Rigidbody insideRigidbody;

    public Grabbable grabbedGrabbable;

    public string tagToGrab = "Moveable";
    public bool makeKinematic;

    public bool tmpKinematic;
    public bool inside;

    public int right;


    public virtual void _WhileGrabbing(){

        WhileGrabbing();
    }
    public virtual void WhileGrabbing(){}
    public virtual void _OnRelease(){
        
        grabbing = false;
        insideView.ClearOwnership();
        insideRigidbody.isKinematic = tmpKinematic;
        if( grabbedGrabbable == null ){ Debug.Log("You have a grab triggered with no grab"); }else{
            grabbedGrabbable.ReleaseObject( view.ownerID , right );
        }
        OnRelease();
    }

    public virtual void OnRelease(){}
    public virtual void _OnGrab(){
        tmpKinematic = insideRigidbody.isKinematic;
        insideRigidbody.isKinematic = makeKinematic;
        insideRealtime.RequestOwnership();
        insideView.RequestOwnership();
        grabbing = true;
        if( grabbedGrabbable == null ){ Debug.Log("You have a grab triggered with no grab");}else{
            grabbedGrabbable.GrabObject( view.ownerID , right );
        }
        OnGrab();
    }
    public virtual void OnGrab(){}

    public virtual void _CheckForGrab(){
        CheckForGrab();
    }
    public virtual void CheckForGrab(){}

    public void Update(){
        if( view.isOwnedLocally ){  
            _CheckForGrab();
            if( grabbing ){
                // Double Check to see if ours!
                if( insideRealtime  != null ){
                    if( insideRealtime.isOwnedLocally ){
                    _WhileGrabbing();
                    }
                }
            }
        }

    }
}
