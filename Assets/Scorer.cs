using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR;
using TMPro;
using IMMATERIA;

public class Scorer: RealtimeComponent {

    private BlarpScoreModel _model;
    public RealtimeAvatarManager manager;
    public TextMesh text;

    int score;

     private BlarpScoreModel model {
      set{

          if (_model != null) {
                // Unregister from events
                _model.scoreDidChange -= ValueChanged;
            }


        _model = value;


         if (_model != null) {
            ChangeText();
            // Register for events so we'll know if the color changes later
            _model.scoreDidChange += ValueChanged;
          }
      }
    
    }

    public void ValueChanged(BlarpScoreModel model , int value){
      ChangeText();
    }

    public void ChangeText(){
      text.text = "Your Together Score is: " + _model.score;
      print("Value Changes over here  " + _model.score);
    }


    public void NewScore() {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.
        _model.score = _model.score + 1;
    }

}

