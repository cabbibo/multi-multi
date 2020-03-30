using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class HandBuffer : TransformBuffer
{
  

  public HumanBuffer buffer;


  public override void Create(){

    List<Transform> tmpT = new List<Transform>();

    for( int i = 0; i < buffer.humans.Length; i++ ){
        tmpT.Add(buffer.humans[i].LeftHand);
        tmpT.Add(buffer.humans[i].RightHand);
    }

    transforms = tmpT.ToArray();
    print(transforms.Length);
  

  }
}
