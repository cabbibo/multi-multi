using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using IMMATERIA;

public class Moveable : MonoBehaviour
{

    public bool moving;
    public Transform movingTransform;

    public Collider insideCollider;


    public void TriggerDown( Collider collider){

        if( insideCollider == collider ){
        }

    }

    public void OnTriggerEnter(Collider c){
        insideCollider = c;
    }

    public void OnTriggerExit( Collider c ){
        insideCollider = null;
    }

    
}
