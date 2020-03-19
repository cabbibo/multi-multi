using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;



public class GetInputs: MonoBehaviour
{

    public float rightTrigger;
    public float leftTrigger;
   
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

    void Update()
    {
        foreach (var device in devicesWithTrigger)
        {

          if( device.role == UnityEngine.XR.InputDeviceRole.LeftHanded){
            print( "leftttie");
            float lt;
            device.TryGetFeatureValue(CommonUsages.trigger, out lt); // did get a value
            print( lt );
            leftTrigger = lt;
          }

          if( device.role == UnityEngine.XR.InputDeviceRole.RightHanded)
            device.TryGetFeatureValue(CommonUsages.trigger, out rightTrigger); // did get a value
  
        }

       
    }
}