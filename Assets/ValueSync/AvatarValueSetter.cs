﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR;
using TMPro;
using IMMATERIA;

public class AvatarValueSetter : RealtimeComponent {

    private AvatarModel _model;
    public Human human;
    public RealtimeAvatarVoice voice;



     private AvatarModel model {
        set {
            // Store the model
            _model = value;
        }
    }
    


private List<InputDevice> devicesWithTrigger;

    private void Awake()
    {

        devicesWithTrigger = new List<InputDevice>();
    }

    void OnEnable()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach(InputDevice device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithTrigger.Clear();
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        float discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.trigger, out discardedValue))
        {
            devicesWithTrigger.Add(device); // Add any devices that have a primary button.
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithTrigger.Contains(device))
            devicesWithTrigger.Remove(device);
    }

  

    public void Update(){
      if (realtimeView.isOwnedLocally) {

          // Update the model to have the latest input values
          GetInputAxis();
          _model.debug = realtimeView.ownerID;
      }else{
        //print("non local owned");

      }

      human.oLeftTrigger = human.LeftTrigger;
      human.oRightTrigger = human.RightTrigger;
      human.oVoice = human.Voice;
      human.oDebugVal = human.DebugVal;



      human.LeftTrigger   = _model.leftTrigger;
      human.RightTrigger  = _model.rightTrigger;


      human.Voice     = _model.voice;
      human.DebugVal  = _model.debug;

    }

    public void GetInputAxis(){
        foreach (var device in devicesWithTrigger)
        {
          if( device.role == UnityEngine.XR.InputDeviceRole.LeftHanded){
            float lt;
            device.TryGetFeatureValue(CommonUsages.trigger, out lt); // did get a value
            _model.leftTrigger = lt;
          }

          if( device.role == UnityEngine.XR.InputDeviceRole.RightHanded){
            float rt;
            device.TryGetFeatureValue(CommonUsages.trigger, out rt); // did get a value
            _model.rightTrigger = rt;
          }
  
        }

        if( voice ){ _model.voice = voice.voiceVolume;  }
    }
}