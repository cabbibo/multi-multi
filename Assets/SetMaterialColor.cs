using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class SetMaterialColor : Cycle
{
    public Color color;
    public string colorName = "_Color";

    public Body[] bodies;
   
    public override void OnLive(){
        for( int i = 0; i < bodies.Length; i++ ){
            bodies[i].mpb.SetColor(colorName,color);
        }
    }
}
