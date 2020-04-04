using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR;
using TMPro;
using IMMATERIA;

public class DesktopAvatarValueSetter : RealtimeComponent {

    public float mouseDown;
    public Vector2 mousePosition;
    public float voice;
    public float debug;

    public Vector2 screen;


    public Camera camera;


    public float screenDistance;

    
    public DesktopAvatarSelfValues selfSetter;

    public RealtimeAvatarVoice avatarVoice;
    private DesktopAvatarModel _model;


     private DesktopAvatarModel model {
        set {
            // Store the model
            _model = value;
        }
    }
    


    private void Start()
    {
        camera = gameObject.AddComponent<Camera>();
        camera.enabled = false;
        selfSetter = GameObject.FindGameObjectWithTag("DesktopBase").GetComponent<DesktopAvatarSelfValues>();
        
    }

    public void Update(){
      if (realtimeView.isOwnedLocally) {

          // Update the model to have the latest input values
          GetInfo();
          
      }else{
        //print("non local owned");

      }

        screen = _model.screen;
        mousePosition = _model.mousePosition;
        voice = _model.voice;
        mouseDown = _model.mouseDown;
        screenDistance = _model.screenDistance;

        camera.fieldOfView = _model.fieldOfView;
        camera.aspect = _model.screen.x / _model.screen.y;

    }

    public void GetInfo(){
        
        SetToLocal();
        _model.debug = realtimeView.ownerID;
        if( avatarVoice ){ _model.voice = Mathf.Lerp( _model.voice , avatarVoice.voiceVolume , .3f);  }

    }


    public void SetToLocal(){
        _model.screen = selfSetter.screen;
        _model.mousePosition = selfSetter.mousePosition;
        _model.mouseDown = selfSetter.mouseDown;
        _model.fieldOfView = selfSetter.fieldOfView;
        _model.screenDistance = selfSetter.screenDistance;
    }

}