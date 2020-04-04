using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Grabbable :  RealtimeComponent
{

    public RealtimeAvatarManager avatarManager;

    public int grabbingClientID;
    public bool isGrabbed;
    public int hand;

    private LineRenderer lineRenderer;
    private float startLRWidth;
    private GrabbableModel _model;


     private GrabbableModel model {
        set {
            // Store the model
            _model = value;
        }
    }

    

    public void GrabObject(int clientID , int hand ){
        _model.isGrabbed = true;
        _model.grabbingClientID = clientID;
        _model.hand = hand;
    }

    public void ReleaseObject(int clientID, int hand ){
        _model.isGrabbed = false;
        _model.grabbingClientID = -1;
        _model.hand = hand;
    }


    void Start(){
        avatarManager = GameObject.FindGameObjectWithTag("REALTIME").GetComponent<RealtimeAvatarManager>();
        lineRenderer = GetComponent<LineRenderer>();
        startLRWidth = lineRenderer.startWidth;
    }
    void Update(){

        isGrabbed = _model.isGrabbed;
        grabbingClientID = _model.grabbingClientID;
        hand = _model.hand;


        if( isGrabbed ){
            RealtimeAvatar a = avatarManager.avatars[grabbingClientID];
            Transform t = a.leftHand;
            if( hand == 1 ){
                t = a.rightHand;
            }
            lineRenderer.SetWidth(startLRWidth,startLRWidth);
            lineRenderer.SetPosition( 0 , transform.position );
            lineRenderer.SetPosition( 1 , t.position );
        }else{
            lineRenderer.SetWidth(0, 0);
        }



    }
   



}
