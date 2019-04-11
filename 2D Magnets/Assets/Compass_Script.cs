﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Compass_Script : MonoBehaviour
{
    public float radian = 1.75f; //radias per sec
    public GameObject magnets;
    
    //public Vector3 point_N;
    
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 point_N = new Vector3(transform.position.x - 0.375f, transform.position.y, transform.position.z);
        magnets = GameObject.Find("Magnet");
    }

    // Update is called once per frame
    void Update()
    {

        bool check = false;
        // magnet = magnets.GetComponent<Magnet_Script>
        
        Magnet_Script magnet = magnets.GetComponent<Magnet_Script>();

        Debug.Log("This is magnet.colliders " + magnet.colliders);
        /*
        foreach (var collider in magnet.colliders)
        {
            Debug.Log("In collider" + collider);
            if (collider.Equals(this.GetComponent<Collider>()))
            {
                check = true;
            }
            Debug.Log("check is " + check + " First Check");
        }
        */
        Debug.Log("check is " + check + " Second Check");
        if (true) { //set true back to check
            //creates new direction
            var attractor = (magnet.North - transform.position);
            var direction_a = (attractor / attractor.magnitude);
            var repulse = (transform.position - magnet.South);
            var direction_s = (repulse / repulse.magnitude);
            var attra_str = (1 / (attractor.sqrMagnitude));
            var repul_str = (1 / (repulse.sqrMagnitude));

            var fin_direct = ((attra_str * attractor) + (repul_str * repulse));

            Debug.DrawLine(transform.position, fin_direct, Color.red);

            //rotates toward new direction
            var vec_pointing = (transform.right - transform.position);
            var vec_direct = (vec_pointing / vec_pointing.magnitude);

            float angle = Vector3.Angle(vec_direct, fin_direct);

            float speed = (radian * Time.deltaTime);

            if (angle > 0)
            {
                Vector3 newDir = Vector3.RotateTowards(vec_pointing, vec_direct, speed, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir);
                /*
                var dir_pivot = vec_pointing;
                var rot_y = 100.268f * Time.deltaTime;
                Vector3 rotationVector = new Vector3(0f, rot_y, 0f);
                dir_pivot = Quaternion.Euler(rotationVector) * dir_pivot;
                point_N = dir_pivot + transform.position;
                */
            }



        }
    }
}