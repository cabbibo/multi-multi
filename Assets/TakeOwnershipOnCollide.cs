using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class TakeOwnershipOnCollide : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision c){
        if( c.collider.GetComponent<RealtimeTransform>() != null ){
            if( c.collider.GetComponent<RealtimeView>().isOwnedLocally || c.collider.GetComponent<RealtimeTransform>().isOwnedLocally){
                GetComponent<RealtimeView>().RequestOwnership();
                GetComponent<RealtimeTransform>().RequestOwnership();
            }
        }
    }
}
