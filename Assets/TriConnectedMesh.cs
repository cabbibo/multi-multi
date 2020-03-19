using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMMATERIA {
public class TriConnectedMesh : Cycle
{

  public Particles particles;
  public Life life;
  public Life triLocation;
  public Life resolve;
  public Body body;

  public Body baseBody;

  public override void Create(){


    particles.count = ((MeshVerts)baseBody.verts).meshFilter.sharedMesh.vertices.Length;

    SafeInsert( particles );

    SafeInsert( life );
    SafeInsert( triLocation );
    SafeInsert( resolve );

    SafeInsert( body ); // particles and tris added to body



  }

  public override void Bind(){

    life.BindPrimaryForm( "_ParticleBuffer" , particles );
    life.BindForm("_VertBuffer" , baseBody.verts );
    
    triLocation.BindPrimaryForm( "_ParticleBuffer" , particles );
    triLocation.BindForm("_VertBuffer" , baseBody.verts );

    resolve.BindPrimaryForm( "_ParticleBuffer" , particles );


  }

  public override void WhileLiving( float v ){

    

  }



}
}