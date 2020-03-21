using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class HandConnections : TransformBuffer
{
  

  public HumanBuffer buffer;


  public override void Create(){

    List<Transform> tmpT = new List<Transform>();

      tmpT.Add(buffer.humans[0].LeftHand);
      tmpT.Add(buffer.humans[0].RightHand);
    for( int i = 0; i < buffer.humans.Length-1; i++ ){

      print("helllos");
      for( int j = i+1; j < buffer.humans.Length; j++ ){

        tmpT.Add(buffer.humans[i].LeftHand);
        tmpT.Add(buffer.humans[j].LeftHand);

        tmpT.Add(buffer.humans[i].RightHand);
        tmpT.Add(buffer.humans[j].RightHand);


        tmpT.Add(buffer.humans[i].LeftHand);
        tmpT.Add(buffer.humans[j].RightHand);


        tmpT.Add(buffer.humans[i].RightHand);
        tmpT.Add(buffer.humans[j].LeftHand);


        tmpT.Add(buffer.humans[j].LeftHand);
        tmpT.Add(buffer.humans[j].RightHand);
        print( "hjmmmm it  me");

      }
    }

    transforms = tmpT.ToArray();
    print(transforms.Length);
  

  }
}
