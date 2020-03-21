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

      buffer.humans = new Human[ avatarManager.avatars.Count ];

      print( avatarManager.avatars.Count  );
      print( buffer.humans.Length  );
      int index = 0;
      foreach(KeyValuePair<int, RealtimeAvatar> entry in avatarManager.avatars){ 
        buffer.humans[ index ] = entry.Value.GetComponent<Human>();
        print( buffer.humans[0].LeftHand.transform.position );
        index ++;
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
