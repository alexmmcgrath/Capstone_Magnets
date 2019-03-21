using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creation : MonoBehaviour
{
    
    public GameObject North;
    public GameObject South;
    public Vector3 Capsule_position = new Vector3(1.5f, 0, 0);  // set center of sphere for the start and end of capsule

    public LayerMask FieldLines;

    void Start()
    {
       Instantiate(North, new Vector3(-1.75f, 0, 0), Quaternion.identity);
       Instantiate(South, new Vector3(1.75f, 0, 0), Quaternion.identity);
     
       
    }
    void Update()
    {
        Collider[] collider = Physics.OverlapCapsule((transform.position - Capsule_position), (transform.position + Capsule_position), 2.5f, FieldLines);
    }


}
