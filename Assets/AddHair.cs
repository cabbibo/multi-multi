using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

public class AddHair : MonoBehaviour
{

    public God god;
    public TransferLifeForm hair;


    // Start is called before the first frame update
    void Start()
    {
        god = GameObject.FindGameObjectsWithTag("God")[0].GetComponent<God>();

        hair.skeleton = GameObject.Find("PlaneMesh").GetComponent<MeshVerts>();

        god.SafeInsert( hair );

        god.Rebuild();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
