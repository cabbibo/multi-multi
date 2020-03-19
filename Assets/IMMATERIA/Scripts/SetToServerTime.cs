using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMMATERIA {
public class SetToServerTime : Cycle
{

  public Animator animator;

  public float oT;
  public float delta;
  public override void Create(){
    if( animator == null ){ animator = GetComponent<Animator>();}
  }

  public override void OnBirthed(){
    animator.Play("boneFish", 0, 0.0f);
    oT = data.SERVER_TIME;
  }

  public override void WhileLiving(float v){
    delta = data.SERVER_TIME - oT;
    animator.Update(delta);
    oT = data.SERVER_TIME;
  }
}
}