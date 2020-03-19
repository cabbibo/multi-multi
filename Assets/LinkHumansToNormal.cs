using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;
using Normal.Realtime;

public class LinkHumansToNormal : Cycle
{


    public RealtimeAvatarManager manager;
    public HumanBuffer buffer;
   
    public void Recreate(){
      Reset();
      _Destroy(); 
      _Create(); 
      _OnGestate();
      _OnGestated();
      _OnBirth(); 
      _OnBirthed();
    }


    public void OnEnable(){
      manager.avatarCreated += AvatarCreated;
    }

    public void OnDisable(){
      manager.avatarCreated -= AvatarCreated;
    }

    public void AvatarCreated( RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar){

      buffer.humans = new Human[ avatarManager.avatars.Count ];
      int index = 0;
      foreach(KeyValuePair<int, RealtimeAvatar> entry in avatarManager.avatars){ 
        buffer.humans[ index ] = entry.Value.GetComponent<Human>();
        print( buffer.humans[0].LeftHand.transform.position );
        index ++;
      }
    }

}
