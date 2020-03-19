using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;


public class BindParticlesOnParticles : Binder
{

    public ParticlesOnParticles particles;

    public override void Bind(){
        toBind.BindInt( "_VertsPerVert", ()=> particles.particlesPerParticle );
        toBind.BindForm( "_BaseBuffer", particles.baseParticles );
    }
}
