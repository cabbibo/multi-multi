using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class HumanParticles : Particles
{

  public float radius;
  public float power;
  public HumanBuffer humanBuffer;
  public int _ParticlesPerPerson;
  public Life life;

  public override void SetCount(){
    print( humanBuffer.humans.Length );
    count = _ParticlesPerPerson * humanBuffer.humans.Length;
  }

  public override void Bind(){
    life.BindForm("_HumanBuffer", humanBuffer);
    life.BindFloat("_HumanRadius", () => this.radius);
    life.BindFloat("_HumanForce", () => this.power);
    life.BindInt("_ParticlesPerPerson", () => this._ParticlesPerPerson );
  }
  
}
