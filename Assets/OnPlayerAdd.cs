using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class OnPlayerAdd : MonoBehaviour
{

  public RealtimeAvatarManager manager;
  public Transform localTransform;
  public Transform fakeHuman;
  public float Radius;

    // Start is called before the first frame update
    void Start()
    {
        manager.avatarCreated += AvatarCreated;
    }

    public void AvatarCreated( RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar){

      int count = avatarManager.avatars.Count;
      if( count == 1 ){
        float angle = 1 * 6.28f;
        angle /= (count+1);

        float x = Mathf.Sin( angle );
        float y = -Mathf.Cos( angle );

         fakeHuman.position = new Vector3( x * Radius , 0 , y * Radius);

         fakeHuman.LookAt( Vector3.zero );
      }else{
        fakeHuman.position = Vector3.left * 10000;
      }
      foreach(KeyValuePair<int, RealtimeAvatar> entry in avatarManager.avatars)
      {
        if( isLocalAvatar ){

        float angle = (float)entry.Key * 6.28f;
        angle /= (count+1);

        float x = Mathf.Sin( angle );
        float y = -Mathf.Cos( angle );

         localTransform.position = new Vector3( x * Radius , 0 , y * Radius);

         localTransform.LookAt( Vector3.zero );
        }
      }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
