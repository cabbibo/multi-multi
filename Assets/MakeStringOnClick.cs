using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStringOnClick : MonoBehaviour
{

    public keyboardDriver driver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        print("hi");
        if(driver.connected ){
            
            if(!driver.makingString ) driver.StartNewMessage(); 
            else                        driver.EndMessage();
        }
    }
}
