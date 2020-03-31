using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class AddCycle : MonoBehaviour
{

    public God god;
    public Cycle cycle;


    // Start is called before the first frame update
    void Start()
    {

        if( cycle != null ){
            god = GameObject.FindGameObjectsWithTag("God")[0].GetComponent<God>();
            god.SafeInsert( cycle );
            god.Rebuild();
        }

    }

    void OnDestroy(){
       if( cycle != null ) god.Cycles.Remove( cycle );
    }
}
