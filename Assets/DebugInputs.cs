using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DebugInputs : MonoBehaviour {


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

          // Update the model to have the latest input values
          GetInputAxis();

    }

    public void GetInputAxis(){
        foreach (var device in devicesWithTrigger)
        {

          print( "getting it");

          if( device.role == UnityEngine.XR.InputDeviceRole.LeftHanded){
            float lt;
            device.TryGetFeatureValue(CommonUsages.trigger, out lt); // did get a value
            print( lt );
          }

          if( device.role == UnityEngine.XR.InputDeviceRole.RightHanded){
            float rt;
            device.TryGetFeatureValue(CommonUsages.trigger, out rt); // did get a value
            print( rt );
          }
  
        }
    }
}