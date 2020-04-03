using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectTargets : MonoBehaviour
{

    public Transform[] targets;

    public int totalCount;

    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        totalCount = 0;
        for( int i = 0; i < targets.Length; i++ ){
            totalCount += i;
        }

        lineRenderer.positionCount = totalCount * 3;
        
    }

    // Update is called once per frame
    void Update()
    {

        int index = 0;
        for( int i = 0; i<targets.Length-1; i++ ){
            for( int j = i+1; j < targets.Length; j++ ){
                lineRenderer.SetPosition(index *3 + 0 , targets[i].position);
                lineRenderer.SetPosition(index *3 + 1 , targets[j].position);
                lineRenderer.SetPosition(index *3 + 2 , targets[i].position);
                index ++;
            }
        }
        
    }
}
