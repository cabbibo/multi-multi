using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class PlayInEditMode : MonoBehaviour
{
    public void OnEnable(){
      GetComponent<AudioSource>().Play();
    }    
}
