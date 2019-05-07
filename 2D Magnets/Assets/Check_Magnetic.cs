using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Magnetic : MonoBehaviour
{

    public bool isMagnetic = false;

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public bool Player_magnetic(bool press)
    {
        if (press)
        {
            
            if (isMagnetic == false)
            {
                isMagnetic = true;
            }
            else
                isMagnetic = false;
        }
        Debug.Log(isMagnetic);
        return isMagnetic;
    }

}
