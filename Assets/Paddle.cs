using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using IMMATERIA;

public class Paddle : MonoBehaviour
{

    public Transform hand;
    public Human human;
    public bool rightHand;
    private Rigidbody rb;
    public float force;
    public float height;
    public float width;
    private LineRenderer lr;

    private RealtimeTransform _realtimeTransform;
    private RealtimeView _realtimeView;
    bool started;
    int frame;    
    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        _realtimeTransform = GetComponent<RealtimeTransform>();
        _realtimeView = GetComponent<RealtimeView>();

        lr = GetComponent<LineRenderer>();

      started = false;
      frame = 0;

       

    }


    // Update is called once per frame
    void Update()
    {

      frame ++;
      if( frame == 3 ){
          getHuman();
      }


      if( started ){
        hand = human.LeftHand;
      }
    }

    public void VerifyOwnedByLocalPlayer() {
        if (_realtimeTransform.isOwnedLocally)
            return; // We're already owned locally, so we're good.
        
        _realtimeTransform.RequestOwnership();
    }

    public void ApplyFoces() {

        if( started ){

            hand = human.LeftHand;

            float h2 = height * .5f;
            float w2 = width * .5f;

            Vector3 p1 =  hand.transform.up * h2 + hand.transform.right * w2 + hand.forward * .1f;
            Vector3 p2 =  hand.transform.up * h2 - hand.transform.right * w2 + hand.forward * .1f;
            Vector3 p3 = -hand.transform.up * h2 + hand.transform.right * w2 + hand.forward * .1f;
            Vector3 p4 = -hand.transform.up * h2 - hand.transform.right * w2 + hand.forward * .1f;


            Vector3 t1 =  transform.up * h2 + transform.right * w2;
            Vector3 t2 =  transform.up * h2 - transform.right * w2;
            Vector3 t3 = -transform.up * h2 + transform.right * w2;
            Vector3 t4 = -transform.up * h2 - transform.right * w2;

            float triggerVal = human.LeftTrigger;
            
            rb.AddForceAtPosition( -((transform.position + t1) - (hand.position + p1))  * force ,(transform.position + t1));
            rb.AddForceAtPosition( -((transform.position + t2) - (hand.position + p2))  * force ,(transform.position + t2));
            rb.AddForceAtPosition( -((transform.position + t3) - (hand.position + p3))  * force ,(transform.position + t3));
            rb.AddForceAtPosition( -((transform.position + t4) - (hand.position + p4))  * force ,(transform.position + t4));

            lr.SetPosition( 0 ,hand.position + p1);
            lr.SetPosition( 1 ,hand.position + p2);
            lr.SetPosition( 2 ,hand.position + p4);
            lr.SetPosition( 3 ,hand.position + p3);


            transform.localScale = new Vector3( width , height , .02f );
        }
    }


    // Inside of PullTowardsHand

    private void getHuman() {
        // Grab the owner of this blarp
        int ownerID = _realtimeView.ownerID;
        if (ownerID == -1){ print("NOOOOOOO"); } // No owner, this is a bug.

        // Get a reference to the avatar manager that lives on the same game object as Realtime
        Realtime              realtime              = _realtimeView.realtime;
        RealtimeAvatarManager realtimeAvatarManager = realtime.GetComponent<RealtimeAvatarManager>();

        // Get a reference to the avatar, blarpatar, and then human
        RealtimeAvatar        realtimeAvatar        = realtimeAvatarManager.avatars[ownerID];
        Blarpatar             avatarBlarpatar       = realtimeAvatar.GetComponent<Blarpatar>();
        Human                 h                     = avatarBlarpatar.human;

        // Here's your human
        human = h;
        started = true;
    }


}
