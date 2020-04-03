using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class SpawnCorrectAvatar : MonoBehaviour
{

    public Realtime realtime;
    public RealtimeAvatarManager avatarManager;
    public string roomName;
   public bool isVR;
    public DesktopControls desktopControls;

    public GameObject desktopAvatar;
    public GameObject vrAvatar;

   public void Start(){

        avatarManager.localAvatarPrefab = desktopAvatar;

        if( isVR ){ 
            avatarManager.localAvatarPrefab = vrAvatar;
        }


        realtime.Connect( roomName );

   }

}
