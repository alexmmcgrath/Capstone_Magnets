using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet_Script : MonoBehaviour
{
    
    public float DistanceMultiplier;
    public float MagneticPull;
    public float CapsuleRadius;
    public float pole_point;

    public Vector3 North;
    public Vector3 South;
    //public Vector3 Capsule_position = new Vector3(1.5f, 0, 0);  // set center of sphere for the start and end of capsule

    public LayerMask FieldLines;
    public Collider[] colliders;
    //public Vector3 fin_direct;

    void Start()
    {
        North = new Vector3(transform.position.x - pole_point, transform.position.y, transform.position.z);
        South = new Vector3(transform.position.x + pole_point, transform.position.y, transform.position.z);
        Collider[] colliders = Physics.OverlapCapsule(North, South, 2.5f, FieldLines); //put capsule radius where 2.5 is 

    }
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapCapsule(North, South, 2.5f, FieldLines);
        
        foreach(var collider in colliders)
        {
            Rigidbody magnetic = collider.GetComponent<Rigidbody>();

            if (magnetic == null)
            {
                continue;
            }

            Vector3 attract_N = (North - magnetic.transform.position);
            Vector3 attract_S = (South - magnetic.transform.position);

            Vector3 average_attract = ((1/attract_N.sqrMagnitude * attract_N) + (1/attract_S.sqrMagnitude * attract_S)) / 2;

            float distance = average_attract.sqrMagnitude * DistanceMultiplier + 1;

            magnetic.AddForce(average_attract.normalized * (MagneticPull / distance) * magnetic.mass * Time.fixedDeltaTime);

        }
        
    }

}
