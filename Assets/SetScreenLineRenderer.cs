using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenLineRenderer : MonoBehaviour
{

    public DesktopAvatarValueSetter avatar;
    public GameObject collider;

    public LineRenderer lineRenderer;
    private float _ratio;

   public float distance;
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


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        SetFrame();
      
    }


    void SetFrame(){

        Camera cam = Camera.main;

        Vector3  tmpP = cam.transform.position;
        Quaternion tmpR = cam.transform.rotation;

        cam.transform.position = transform.position;
        cam.transform.rotation = transform.rotation;


        if( avatar.screen.x > 0 && avatar.screen.y > 0 ){
        _ratio = (float)avatar.screen.x / (float)avatar.screen.y;

       bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3( borderLeft ,_ratio *borderBottom,distance));  
       bottomRight = Camera.main.ViewportToWorldPoint(new Vector3(1- borderRight,_ratio *borderBottom ,distance));
       topLeft = Camera.main.ViewportToWorldPoint(new Vector3(borderLeft,1-_ratio * borderTop,distance));
       topRight = Camera.main.ViewportToWorldPoint(new Vector3(1-borderRight,1-_ratio * borderTop,distance));

        normal = Camera.main.transform.forward;
        center = Camera.main.ViewportToWorldPoint(new Vector3( .5f , .5f , distance )); 

        lineRenderer.SetPosition(0 , bottomLeft);
        lineRenderer.SetPosition(1 , bottomRight);
        lineRenderer.SetPosition(2 , topRight);
        lineRenderer.SetPosition(3 , topLeft);

        collider.transform.rotation =  Camera.main.transform.rotation;
        collider.transform.position = center;
        collider.transform.localScale = new Vector3( (bottomLeft - bottomRight).magnitude , (bottomLeft - topLeft).magnitude , .001f);
        float fVal = (1 + avatar.voice) * .1f;
            lineRenderer.SetWidth(  fVal , fVal );
        }else{
            
            lineRenderer.SetWidth( 0,0 );
        }
        cam.transform.position = tmpP;
        cam.transform.rotation = tmpR;


    }

    void LateUpdate(){
        SetFrame();
    }
  
}
