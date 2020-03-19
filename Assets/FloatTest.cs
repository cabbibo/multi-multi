using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTest : MonoBehaviour
{
    public float value;
    public float old;
    public float value2;
    public float old2;
    public FloatSync floatSync;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( value != old ){
          floatSync.SetValue(value);
          old = value;
        }
        if( value2 != old2 ){
          floatSync.SetValue2(value2);
          old2 = value2;
        }
    }
}
