using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenLineRenderer : MonoBehaviour
{

    public DesktopAvatarValueSetter avatar;
    public GameObject collider;

    public LineRenderer lineRenderer;
  public float border;

  public float borderLeft;
  public float borderRight;
  public float borderTop;
  public float borderBottom;
  public Vector3 bottomLeft;
  public Vector3 bottomRight;


  public Vector3 topLeft;
  public Vector3 topRight;
  public Vector3 center;

  public float width;
  public float height;
  public Vector3 normal;
  public Vector3 up;
  public Vector3 right;

  public float voiceSizeMin;
  public float voiceSizeMax;
  

    // Start is called before the first frame update
    void Start()
    { 
        SetFrame();
    }


    void SetFrame(){


      

       bottomLeft = avatar.camera.ViewportToWorldPoint(new Vector3( borderLeft ,avatar.camera.aspect *borderBottom,avatar.screenDistance));  
       bottomRight = avatar.camera.ViewportToWorldPoint(new Vector3(1- borderRight,avatar.camera.aspect *borderBottom ,avatar.screenDistance));
       topLeft = avatar.camera.ViewportToWorldPoint(new Vector3(borderLeft,1-avatar.camera.aspect * borderTop,avatar.screenDistance));
       topRight = avatar.camera.ViewportToWorldPoint(new Vector3(1-borderRight,1-avatar.camera.aspect * borderTop,avatar.screenDistance));

        normal = avatar.camera.transform.forward;
        center = avatar.camera.ViewportToWorldPoint(new Vector3( .5f , .5f , avatar.screenDistance )); 

        lineRenderer.SetPosition(0 , bottomLeft);
        lineRenderer.SetPosition(1 , bottomRight);
        lineRenderer.SetPosition(2 , topRight);
        lineRenderer.SetPosition(3 , topLeft);

        collider.transform.rotation =  avatar.transform.rotation;
        collider.transform.position = center;
        collider.transform.localScale = new Vector3( (bottomLeft - bottomRight).magnitude , (bottomLeft - topLeft).magnitude , .001f);
        float fVal = Mathf.Lerp( voiceSizeMin , voiceSizeMax , avatar.voice );
        
        lineRenderer.SetWidth(  fVal , fVal );
   

    }

    void LateUpdate(){
        SetFrame();
    }
  
}
