using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class LockToServerTime : MonoBehaviour
{

    public Realtime realtime;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {

        realtime.didConnectToRoom += Connect;
        
    }


    public void Connect( Realtime rt ){
        print("CONNETIONS");
        print( source.time );
        print( realtime.room.time%source.clip.length);
        double v = realtime.room.time%source.clip.length;
        print( (float)v);
        source.time = (float)v;
        source.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       
    }
}
