using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class OnPlayerAdd : MonoBehaviour
{

  public RealtimeAvatarManager manager;
  public Transform localTransform;

    // Start is called before the first frame update
    void Start()
    {
        manager.avatarCreated += AvatarCreated;
    }

    public void AvatarCreated( RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar){
      foreach(KeyValuePair<int, RealtimeAvatar> entry in avatarManager.avatars)
      {
        if( isLocalAvatar ){

        float angle = (float)entry.Key;

        float x = Mathf.Sin( angle );
        float y = -Mathf.Cos( angle );

         localTransform.position = new Vector3( x * 1 , 0 , y * 1);

         localTransform.LookAt( Vector3.zero );
        }
      }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
