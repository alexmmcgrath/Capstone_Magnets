using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet_Script : MonoBehaviour
{
    
    public Vector3 North;
    public Vector3 South;
    //public Vector3 Capsule_position = new Vector3(1.5f, 0, 0);  // set center of sphere for the start and end of capsule

    public LayerMask FieldLines;
    public Collider[] colliders;
    //public Vector3 fin_direct;

    void Start()
    {
        North = new Vector3(transform.position.x - 1.75f, transform.position.y, transform.position.z);
        South = new Vector3(transform.position.x + 1.75f, transform.position.y, transform.position.z);
        Collider[] colliders = Physics.OverlapCapsule(North, South, 2.5f, FieldLines);

    }
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapCapsule(North, South, 2.5f, FieldLines);
        /*
        foreach(var collider in colliders)
        {
            Rigidbody comp = collider.GetComponent<Rigidbody>();
            var attractor = (North - comp.position);
            var direction_a = (attractor / attractor.magnitude);
            var repulse = (comp.position - South);
            var direction_s = (repulse / repulse.magnitude);
            var attra_str = (1 / (attractor.sqrMagnitude));
            var repul_str = (1 / (repulse.sqrMagnitude));

            fin_direct = ((attra_str * attractor) + (repul_str * repulse));

        }
        */
    }

}
