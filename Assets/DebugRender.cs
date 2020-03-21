using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using IMMATERIA;
public class DebugRender : Cycle
{

    public Form form;
    public int countMultiplier;
    public int vertsPerVert;
    public Material material;

    private MaterialPropertyBlock mpb;
  public override void WhileDebug(){
    if( mpb == null ){ mpb = new MaterialPropertyBlock(); }

    mpb.SetBuffer("_VertBuffer", form._buffer);
    mpb.SetInt("_Count",form.count);
    mpb.SetInt("_CountMultiplier", countMultiplier);
    mpb.SetInt("_VertsPerVert", vertsPerVert);

    Graphics.DrawProcedural(material,  new Bounds(transform.position, Vector3.one * 5000), MeshTopology.Triangles, form.count * countMultiplier * 3 * 2 , 1, null, mpb, ShadowCastingMode.Off, true, LayerMask.NameToLayer("Debug"));

  }
}
