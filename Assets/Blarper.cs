using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;
using Normal.Realtime;



public class Blarper : VrGrabber
{

    public float force;
    public LineRenderer lr;
    public override void WhileGrabbing(){
        Vector3 dif = insideTransform.position - transform.position;
        insideRigidbody.AddForce( dif * force );
        lr.SetPosition( 0 , insideTransform.position);
        lr.SetPosition( 1 , transform.position );
    }

    public override void OnRelease(){
        lr.SetPosition( 0 , Vector3.zero );
        lr.SetPosition( 1 , Vector3.zero );
        
        if( makeKinematic ) insideRigidbody.velocity = -(insideTransform.position-transform.position) / Time.deltaTime;

        if( inside == false ){
            insideTransform = null;
            insideRealtime = null;
            insideRigidbody = null;
        }
    }
}
