using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class SetMaterialTexture: Cycle
{
    public Texture texture;
    public string textureName = "_MainTex";

    public Body[] bodies;
   
    public override void OnLive(){
        for( int i = 0; i < bodies.Length; i++ ){
            bodies[i].mpb.SetTexture(textureName,texture);
        }
    }
}
