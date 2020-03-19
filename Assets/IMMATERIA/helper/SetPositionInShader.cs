using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IMMATERIA {
public class SetPositionInShader : Cycle
{

    public string nameInShader;
    public Transform target;


    private Renderer render;

    // Start is called before the first frame update
    public override void Create()
    {
      render = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    public override void WhileLiving( float v ){

     // print("setting");
        render.sharedMaterial.SetVector( "_EyePos" , target.position );
    }
}
}