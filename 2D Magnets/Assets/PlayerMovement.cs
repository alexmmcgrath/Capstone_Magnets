using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Check_Magnetic magnetism;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool setMagnet = false;
    bool reset = false;
    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Debug.Log(horizontalMove);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            Debug.Log(jump);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            setMagnet = true;
            //Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            //Debug.Log(setMagnet);
            
        }

        if (Input.GetButtonDown("Fire3"))
        {
            reset = true;
        }

        
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        magnetism.Player_magnetic(setMagnet);
        setMagnet = false;
        if (reset == true)
        {
            reset = false;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}
