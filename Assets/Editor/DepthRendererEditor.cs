using UnityEngine;
using UnityEditor;

namespace IMMATERIA {
[CustomEditor(typeof(DepthRenderer))]
public class DepthRendererEditor : Editor 
{  
   public override void OnInspectorGUI()
    {
       

        DepthRenderer god = (DepthRenderer)target;
        if(GUILayout.Button("Rebuild"))
        {
            //god.Rebuild();
        }

         DrawDefaultInspector();


    }


  void OnDrawGizmosSelected()
    {


        DepthRenderer god = (DepthRenderer)target;
        if (god != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(god.transform.position, Vector3.zero);
        }
    }

   


}
}