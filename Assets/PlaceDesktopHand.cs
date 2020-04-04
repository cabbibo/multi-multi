using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDesktopHand : MonoBehaviour
{
    public DesktopAvatarSelfValues avatar;

    // Update is called once per frame
    void Update()
    {

        
        Ray ray = Camera.main.ScreenPointToRay( avatar.mousePosition );
        transform.position = ray.origin + ray.direction * avatar.screenDistance;
    
    }
}
