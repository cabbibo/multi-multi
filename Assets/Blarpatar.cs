using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR;
using IMMATERIA;


// This class lives on the avatar root
public class Blarpatar : MonoBehaviour{
    private RealtimeView _realtimeView;
    public Human human;
    public PullTowardsHand  blarp;
    public Paddle  shield;
    public GameObject blarpPrefab;
    public GameObject shieldPrefab;

     void Start() {
        _realtimeView = GetComponent<RealtimeView>();

        if (_realtimeView.isOwnedLocally) {
            // Local player avatar, let's create a blarp!
            GameObject playerBlarpGameObject = Realtime.Instantiate(blarpPrefab.name, true, true, true);
            blarp = playerBlarpGameObject.GetComponent<PullTowardsHand>();
           

            GameObject playerBlarpGameObject1 = Realtime.Instantiate(shieldPrefab.name, true, true, true);
            shield = playerBlarpGameObject1.GetComponent<Paddle>();
          
        }
    }

     void Update() {
        if (blarp != null) {
            blarp.VerifyOwnedByLocalPlayer();
            blarp.ApplyFoces();
        }

        if (shield != null) {
            shield.VerifyOwnedByLocalPlayer();
            shield.ApplyFoces();
        }
    }
}