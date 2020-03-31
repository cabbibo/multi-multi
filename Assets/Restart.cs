using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Restart : MonoBehaviour
{

    public Transform startTransform;
    public RealtimeTransform realtimeTransform;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        realtimeTransform = GetComponent<RealtimeTransform>();
        rigidbody = GetComponent<Rigidbody>();

        //if( realtimeTransform.isOwnedByWorld ){ realtimeTransform.RequestOwnership(); }
    }

    // Update is called once per frame
    void OnCollisionEnter( Collision c ){

        if( c.collider.tag == "Ground" ){
            if( realtimeTransform != null){
                if( realtimeTransform.isOwnedLocally ){
                    rigidbody.isKinematic = true;
                    transform.position = startTransform.position;
                    rigidbody.isKinematic = false;
                }else{
                }
            }
        }

    }


}
