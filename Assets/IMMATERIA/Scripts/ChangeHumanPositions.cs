using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHumanPositions : MonoBehaviour
{


  public Transform[] positions;
  public int currPosition;
  public Transform toCopy;

  public int headForces;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


      if ( Input.GetKeyDown(KeyCode.RightArrow) ){
        currPosition ++;
        currPosition %= positions.Length; 
        toCopy.position = positions[currPosition].position;
        toCopy.rotation = positions[currPosition].rotation;
      }

  }
     
}
