using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class ParticlesOnParticles : Particles
{
   public Form baseParticles;
   public int particlesPerParticle;
   public override void SetCount(){
       count = baseParticles.count * particlesPerParticle;
   }

   public void SelfBind(Life toBind){
    toBind.BindInt("_ParticlesPerParticle", ()=> this.particlesPerParticle );
    toBind.BindForm("_BaseBuffer", baseParticles );
    toBind.BindPrimaryForm("_VertBuffer",this);
   }
}
