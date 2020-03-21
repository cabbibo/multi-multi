﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;
using Normal.Realtime;

public class LinkHumansToNormal : Cycle
{


    public RealtimeAvatarManager manager;
    public HumanBuffer buffer;
    public Human fakeHuman;
   
    public void Recreate(){
      print( "rebuilding");
     data.god.Rebuild();
     
     data.god.Rebuild();
    }


    public void OnEnable(){
      manager.avatarCreated += AvatarCreated;
      manager.avatarDestroyed += AvatarDestroyed;
    }

    public void OnDisable(){
      manager.avatarCreated -= AvatarCreated;
      manager.avatarDestroyed -= AvatarDestroyed;
    }

    public void AvatarCreated( RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar){


      // if its just us make a mirror version of us!
      if( avatarManager.avatars.Count == 1 ){


        buffer.humans = new Human[ 2 ];
        int index = 0;
        foreach(KeyValuePair<int, RealtimeAvatar> entry in avatarManager.avatars){ 
          buffer.humans[ index ] = entry.Value.GetComponent<Human>();
          index ++;
        }
        buffer.humans[1] = fakeHuman;
        fakeHuman.transform.GetComponent<HumanToCopy>().copy = true;
        fakeHuman.transform.GetComponent<HumanToCopy>().toCopy = buffer.humans[0];


      }else{
        fakeHuman.transform.GetComponent<HumanToCopy>().copy = false;
        buffer.humans = new Human[ avatarManager.avatars.Count ];
        int index = 0;
        foreach(KeyValuePair<int, RealtimeAvatar> entry in avatarManager.avatars){ 
          buffer.humans[ index ] = entry.Value.GetComponent<Human>();
          index ++;
      }


    }

      Recreate();
    }


    public void AvatarDestroyed(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar){

      buffer.humans = new Human[ avatarManager.avatars.Count ];
      int index = 0;
      foreach(KeyValuePair<int, RealtimeAvatar> entry in avatarManager.avatars){ 
        buffer.humans[ index ] = entry.Value.GetComponent<Human>();
        print( buffer.humans[0].LeftHand.transform.position );
        index ++;
      }

      Recreate();
    }

}
