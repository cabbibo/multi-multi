using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class TurnOffOnSelf : MonoBehaviour
{

    public bool turnOff;
    public RealtimeView view;
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        if( GetComponent<RealtimeView>().isOwnedLocally == true ){
            if( turnOff ) TurnOff();
        }
    }

    public void TurnOff(){
        for( int i = 0; i< objects.Length; i++ ){
            objects[i].SetActive( false );
        }
    }
}
