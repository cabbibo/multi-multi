using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Normal.Realtime;
using IMMATERIA;



[System.Serializable]
public class TriggerEvent : UnityEvent<Human,string>{}
public class TriggerColliderEvent : UnityEvent<Collider>{}
public class SelfEvents : MonoBehaviour
{
   
    public RealtimeView view;
    public Human human;

    public TriggerEvent TriggerDown;
    public TriggerEvent TriggerUp;
    public TriggerColliderEvent TriggerColliderUp;
    public TriggerColliderEvent TriggerColliderDown;



    void Start(){
        human = GetComponent<Human>();
        view = GetComponent<RealtimeView>();
    }



    void Update(){

        if(view.isOwnedLocally){
            if( human.oRightTrigger < .8f &&  human.RightTrigger >= .8f ){ TriggerDown.Invoke( human , "right"); TriggerColliderDown.Invoke(human.RightHandCollider); } 
            if( human.oRightTrigger >= .8f &&  human.RightTrigger < .8f ){ TriggerUp.Invoke( human , "right");  TriggerColliderUp.Invoke(human.RightHandCollider); }
            if( human.oLeftTrigger > .8f &&  human.LeftTrigger >= .8f ){ TriggerDown.Invoke( human , "left");  TriggerColliderDown.Invoke(human.LeftHandCollider);}
            if( human.oLeftTrigger >= .8f &&  human.LeftTrigger < .8f ){ TriggerUp.Invoke( human , "left");  TriggerColliderUp.Invoke(human.LeftHandCollider);}
        }
        
    
    }

}
