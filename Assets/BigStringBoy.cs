using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;

public class BigStringBoy : RealtimeComponent
{
    public TextMesh textMesh;
    private BigStringBoyModel _model;



     private BigStringBoyModel model {
        set {
            // Store the model
            _model = value;
        }
    }

    public RealtimeView view;

    public string fullString;


    public void SetString(string words){
        print("NEW STERING");
        print( "Words");
        SmallStringModel smallString = new SmallStringModel();
        smallString.words = words;
        _model.smallStrings.Add(smallString);
    }
    

    public void Update(){
        

        if( view ){
        fullString = "";
       
    
    
        for( int i = 0; i < _model.smallStrings.Count; i++ ){
           fullString += _model.smallStrings[i].words;
        }

       textMesh.text = fullString;

        }
    }
}
