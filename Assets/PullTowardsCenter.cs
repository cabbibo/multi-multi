using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullTowardsCenter : MonoBehaviour
{
  public LineRenderer lr;
  public Transform center;
    // Start is called before the first frame update
     private Rigidbody rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce( -(transform.position - center.position)  * force );
        lr.SetPosition( 0 , transform.position );
        lr.SetPosition( 1 , center.position);
   }

}
