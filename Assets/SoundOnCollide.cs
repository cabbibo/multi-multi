using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollide : MonoBehaviour
{
   public AudioSource clip;

   public void Start(){
       clip = GetComponent<AudioSource>();
   }
   public void OnCollisionEnter(){
       clip.Play();
   }
}
