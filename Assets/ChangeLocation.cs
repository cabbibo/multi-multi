using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ChangeLocation : MonoBehaviour
{

    public RealtimeTransform rtTransform;
    public RealtimeView rtView;
    public Scorer scorer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt( Camera.main.transform.position );
       
    }

    void OnCollisionEnter( Collision c ){
      RealtimeView rtv = c.collider.gameObject.GetComponent<RealtimeView>();
      if( rtv != null ){
        if(rtv.isOwnedLocally == true ){
          rtTransform.RequestOwnership();
          rtView.RequestOwnership();
          transform.position = Random.insideUnitSphere + new Vector3( 0 , 1 , 0);
          scorer.NewScore();
        }else{

          print("NOT OWNED LOCALLY");
        }
      }
    }
}
