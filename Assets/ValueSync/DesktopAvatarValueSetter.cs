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

    public RealtimeAvatarVoice avatarVoice;
    private DesktopAvatarModel _model;


     private DesktopAvatarModel model {
        set {
            // Store the model
            _model = value;
        }
    }
    


    private void Awake()
    {

    }

    void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    public void Update(){
      if (realtimeView.isOwnedLocally) {

          // Update the model to have the latest input values
          GetInfo();
          _model.debug = realtimeView.ownerID;
      }else{
        //print("non local owned");

      }

        screen = _model.screen;
        mousePosition = _model.mousePosition;
        voice = _model.voice;
        mouseDown = _model.mouseDown;

    }

    public void GetInfo(){

        _model.screen = new Vector2( Screen.width , Screen.height);
        _model.mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

    
        _model.mouseDown = Input.GetMouseButton(0) ? 1 : 0;
        
        _model.debug = realtimeView.ownerID;

          
        if( avatarVoice ){ _model.voice = Mathf.Lerp( _model.voice , avatarVoice.voiceVolume , .3f);  }

    }

}