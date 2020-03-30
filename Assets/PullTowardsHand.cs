using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using IMMATERIA;

public class PullTowardsHand : MonoBehaviour
{

    public Transform hand;
    public Human human;
    public bool rightHand;
    public LineRenderer lr;
    private Rigidbody rb;
    public float force;

    private RealtimeTransform _realtimeTransform;
    private RealtimeView _realtimeView;
    bool started;
    int frame;    
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
        _realtimeTransform = GetComponent<RealtimeTransform>();
        _realtimeView = GetComponent<RealtimeView>();

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
            hand = human.RightHand;     
            lr.SetPosition( 0 , transform.position );
            lr.SetPosition( 1 , hand.position );
        }
    }

    public void VerifyOwnedByLocalPlayer() {
        if (_realtimeTransform.isOwnedLocally)
            return; // We're already owned locally, so we're good.
        
        _realtimeTransform.RequestOwnership();
    }

    public void ApplyFoces() {

        if( started ){
            hand = human.RightHand;
            float  triggerVal = human.RightTrigger;
            rb.AddForce( -(transform.position - hand.position)  * force * triggerVal );
        }
    }


    // Inside of PullTowardsHand

private void getHuman() {
    // Grab the owner of this blarp
    int ownerID = _realtimeView.ownerID;
    if (ownerID == -1){ print("NOOOOOOO"); } // No owner, this is a bug.

    print( ownerID );


    // Get a reference to the avatar manager that lives on the same game object as Realtime
    Realtime              realtime              = _realtimeView.realtime;
    RealtimeAvatarManager realtimeAvatarManager = realtime.GetComponent<RealtimeAvatarManager>();

    print( realtimeAvatarManager.avatars.Count );

    // Get a reference to the avatar, blarpatar, and then human
    RealtimeAvatar        realtimeAvatar        = realtimeAvatarManager.avatars[ownerID];
    Blarpatar             avatarBlarpatar       = realtimeAvatar.GetComponent<Blarpatar>();
    Human                 h                     = avatarBlarpatar.human;


    // Here's your human
    human = h;
    started = true;
}


}
