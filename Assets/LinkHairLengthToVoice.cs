using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class LinkHairLengthToVoice : Cycle
{

    public float minDist;
    public float maxLength;

    public Human human;
    public Hair hair;
    public override void WhileLiving(float v){
        hair.length = Mathf.Lerp( hair.length , human.Voice *  maxLength + minDist , .1f);
    }
}
