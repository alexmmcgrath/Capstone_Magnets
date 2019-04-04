using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Compass : MonoBehaviour
{

    public Vector3 point_N;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 point_N = new Vector3(transform.position.x - 0.375f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Creation direction = GetComponent<Creation>();
        var vec_pointing = (point_N - transform.position);
        var vec_direct = (vec_pointing / vec_pointing.magnitude);

        float angle = Vector3.Angle(vec_direct, direction.fin_direct);


        if(angle == 0)
        {
            
        }
        else if(angle == 180)
        {
            
        }
        else
        {

        }

    }
}
