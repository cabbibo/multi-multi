using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFullScene : MonoBehaviour
{

    public string sceneName;

    // Start is called before the first frame update
    void Awake()
    {
         #if !UNITY_EDITOR
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
