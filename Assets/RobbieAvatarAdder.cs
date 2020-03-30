using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;


[ExecuteAlways]
public class RobbieAvatarAdder : MonoBehaviour
{

    public God god;
    public Cycle baseCycle;

    // Start is called before the first frame update
    void Start()
    {
        god = GameObject.FindGameObjectsWithTag("God")[0].GetComponent<God>();
        god.SafeInsert( baseCycle );

        god.Rebuild();

        
    }
    void OnDestroy(){
        god.Cycles.Remove( baseCycle );
        god.Rebuild();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
