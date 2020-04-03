using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    public Vector3 offset;
    public Transform cam;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = parent.position + cam.right* offset.x + cam.up* offset.y + cam.forward* offset.z;
        transform.LookAt( cam.position );
        transform.Rotate( Vector3.up * 180 );
    }
}
