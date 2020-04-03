using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopControls : MonoBehaviour
{

    public bool canDo;


    public float height;
   
   
    public float radius;
    public float radiusVel;
    public float radiusDampening;
    public float minRadius;
    public float maxRadius;

    public float upOffset;
    public float leftOffset;
    public float mainAngle;
    public float mainAngleVel;
    public float mainAngleDampening;

    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if( canDo ){
            UpdateControls();
        }

    }

    public void UpdateControls(){

        mainAngle += mainAngleVel;
        mainAngleVel *= mainAngleDampening;

        radius -= radiusVel;
        radiusVel *= radiusDampening;

        if( radius < minRadius ){
            radiusVel -= .01f;
        }

         if( radius > maxRadius ){
            radiusVel += .01f;
        }

        transform.position = new Vector3( Mathf.Cos( mainAngle) * radius , height , -Mathf.Sin(mainAngle) * radius);
        transform.LookAt( target );


    }
}
