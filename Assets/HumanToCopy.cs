using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class HumanToCopy : MonoBehaviour
{


  public Human toCopy;
  public Human me;
   
  public bool copy;

  public void Update(){
    if( copy ){
      me.LeftHand.localPosition = toCopy.LeftHand.localPosition;
      me.LeftHand.localRotation = toCopy.LeftHand.localRotation;
      me.RightHand.localPosition = toCopy.RightHand.localPosition;
      me.RightHand.localRotation = toCopy.RightHand.localRotation;
      me.Head.localPosition = toCopy.Head.localPosition;
      me.Head.localRotation = toCopy.Head.localRotation;

      me.LeftTrigger = toCopy.LeftTrigger;
      me.RightTrigger = toCopy.RightTrigger;
      me.Voice = toCopy.Voice;
      me.DebugVal = toCopy.DebugVal;
    }
  }

}
