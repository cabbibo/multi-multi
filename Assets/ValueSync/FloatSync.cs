using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;

public class FloatSync : RealtimeComponent
{

    public TextMesh text;
    public TextMesh text2;
    private FloatModel _model;

    // Update is called once per frame
    void Update()
    {
        
    }

    private FloatModel model{
      set{

          if (_model != null) {
                // Unregister from events
                _model.floatValDidChange -= ValueChanged;
                _model.floatVal2DidChange -= ValueChanged;
            }


        _model = value;


         if (_model != null) {
              ChangeText();

                // Register for events so we'll know if the color changes later
                _model.floatValDidChange += ValueChanged;
                _model.floatVal2DidChange += ValueChanged;
            }
      }
    }

    public void ChangeText(  ){
      string s = " HI: " + _model.floatVal;
      print("HELLOSSS");
      print(s);
      text.text = " HI: " + _model.floatVal;
      text2.text = " HI2: " + _model.floatVal2;
    }

    public void ValueChanged(FloatModel model , float value){
      ChangeText();
    }


    public void SetValue(float v ){
      _model.floatVal = v;
    }

     public void SetValue2(float v ){
      _model.floatVal2 = v;
    }



    
}
