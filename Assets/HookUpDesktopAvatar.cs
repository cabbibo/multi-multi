using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class HookUpDesktopAvatar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject baseObject;
    public DesktopControls controls;
    public RealtimeView view;

    public MoveDesktopCamera controller;
    void Start()
    {
        if( view.isOwnedLocally ){
            baseObject = GameObject.Find("HumanBase");
            controls = baseObject.GetComponent<DesktopControls>();
            controller.controls = controls;
            controls.canDo = true;
        }
        
    }

}
