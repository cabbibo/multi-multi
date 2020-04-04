using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopAvatarSelfValues : MonoBehaviour
{


    public float screenDistance;
    public Vector2 screen;
    public Vector2 mousePosition;

    public float fieldOfView;
    public float nearClipPlane;
    public float farClipPlane;

    public float mouseDown;


    // Start is called before the first frame update
    void Start()
    {
        fieldOfView = Camera.main.fieldOfView;
        nearClipPlane = Camera.main.nearClipPlane;
        farClipPlane = Camera.main.farClipPlane;
        screen = new Vector2( Screen.width , Screen.height);
    
    }

    // Update is called once per frame
    void Update()
    {
        screen = new Vector2( Screen.width , Screen.height);
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mouseDown = Input.GetMouseButton(0) ? 1 : 0;        
        fieldOfView = Camera.main.fieldOfView;
    }

    
}
