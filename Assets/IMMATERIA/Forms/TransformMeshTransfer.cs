using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMMATERIA {
public class TransformMeshTransfer : TransferLifeForm
{


  public Form baseBuffer;
  public Particles shark;

  public override void Bind(){

   transfer.BindForm("_BaseBuffer", baseBuffer);
   transfer.BindForm("_SharkBuffer", shark);
   transfer.BindInt("_VertsPerMesh",() => baseBuffer.count);
  }
}
}