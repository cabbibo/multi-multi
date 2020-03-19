using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IMMATERIA {
public class BindAudioForm : Binder
{ 
    public AudioListenerTexture audio;

    public override void Bind(){
      toBind.BindForm("_AudioBuffer" , audio );
    }


  }
}