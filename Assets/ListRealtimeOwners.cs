using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;

public class ListRealtimeOwners : MonoBehaviour
{

    public RealtimeView view;
    public RealtimeTransform realtimeTransform;
    public TextMesh text;

    void Start(){
        view = GetComponent<RealtimeView>();
        realtimeTransform = GetComponent<RealtimeTransform>();
        
    }
   
    // Update is called once per frame
    void Update()
    {

        string fullString = "View:" + view.ownerID + " || Tra: " + realtimeTransform.ownerID;
        text.text = fullString;
    }
}
