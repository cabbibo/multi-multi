using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class keyboardDriver : MonoBehaviour
{
    public Realtime realtime;
    public bool makingString;
    private BigStringBoy bigStringBoy;

    public GameObject bigStringPrefab;

    public RealtimeTransform bigStringTransform;

    public GameObject bigStringGO;


    // Start is called before the first frame update
    void Start()
    {
        realtime.didConnectToRoom += StartNewMessage;
        
    }


    public void StartNewMessage(Realtime realtime){

        print("connecsst");
        
        if( makingString == true ){ print( "TO MANNY MESSAGIS"); }else{
            bigStringGO = Realtime.Instantiate("BigStringBoy");
            bigStringBoy = bigStringGO.GetComponent<BigStringBoy>();
            bigStringTransform = bigStringGO.GetComponent<RealtimeTransform>();
            bigStringGO.GetComponent<RealtimeView>().RequestOwnership();
            bigStringGO.transform.position = transform.position + transform.forward;
            bigStringGO.transform.rotation = transform.rotation;
            makingString = true;
            print("yaayss");
        }
    }

void OnGUI(){

    if( makingString ){;
        print("sdhsdjs");
    Event e = Event.current;
    if( e.type == EventType.KeyDown ){

        if ( e.keyCode.ToString().Length == 1 &&
            char.IsLetter(e.keyCode.ToString()[0])  ){
            bigStringBoy.SetString(e.keyCode.ToString()[0].ToString());
        }
        if( e.keyCode == KeyCode.Return ){ bigStringBoy.SetString("\n");}
    }

    }

}

void Update(){
    if( makingString ){
    bigStringGO.transform.position = transform.position + transform.forward;
    bigStringGO.transform.rotation = transform.rotation;
    }
}
}
