using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class BindVoice : Binder
{
    public Human human;

    public  float lerpSpeed = 1 ;
    float voice = 0;

    public override void Bind(){
        toBind.BindFloat("_Voice", ()=> human.Voice );
    }
  

    public override void WhileLiving(float v){
        voice = Mathf.Lerp( voice, human.Voice , lerpSpeed );
    }

}
