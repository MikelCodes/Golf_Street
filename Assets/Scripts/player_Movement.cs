﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    public float speed = 10.0f;
    private float translation;
    private float straife;
    //-------------------------------------
    GameObject ball;
    Rigidbody ballrb;
    private float ballXSpeed;
    private float ballZSpeed;
    private float rollTimer;
    private float powerTimer = 0;
    private bool powerOn = false;
    private bool lastPressedW = false;
    private bool lastPressedS = false;
    private bool lastPressedA = false;
    private bool lastPressedD = false;
    private bool ballstate = false;

    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;

        //----------------------------------------------

        ball = GameObject.FindGameObjectWithTag("Ball");
        ballrb = ball.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straife = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straife, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("tab"))
        {
            // turn off the cursor
            Cursor.lockState = CursorLockMode.Locked;
        }

        //----------------------------------------------

        if (powerTimer <= 0)
        {
            if (Input.GetAxis("Vertical") == 1)
            {
                lastPressedW = true;
                lastPressedS = false;
                lastPressedD = false;
                lastPressedA = false;
            }
            if (Input.GetAxis("Vertical") == -1)
            {
                lastPressedW = false;
                lastPressedS = true;
                lastPressedD = false;
                lastPressedA = false;
            }
            if (Input.GetAxis("Horizontal") == 1)
            {
                lastPressedW = false;
                lastPressedS = false;
                lastPressedD = true;
                lastPressedA = false;
            }
            if (Input.GetAxis("Horizontal") == -1)
            {
                lastPressedW = false;
                lastPressedS = false;
                lastPressedD = false;
                lastPressedA = true;
            }
        }

        if ((Input.GetKeyDown("f")) && (powerTimer <= 0))
        {
            if (lastPressedW == true)
            {
                ballXSpeed = 0;
                ballZSpeed = ballZSpeed + 10;
            }
            if (lastPressedS == true)
            {
                ballXSpeed = 0;
                ballZSpeed = -ballZSpeed - 10;
            }
            if (lastPressedD == true)
            {
                ballXSpeed = ballXSpeed + 10;
                ballZSpeed = 0;
            }
            if (lastPressedA == true)
            {
                ballXSpeed = ballXSpeed - 10;
                ballZSpeed = 0;
            }
        }

        if ((Input.GetKeyDown("f")) && (powerOn == false) && (ballstate == false))
        {
            powerOn = true;
            powerTimer = 1;
        }

        if (powerTimer > 0)
        {
            powerTimer = powerTimer - Time.deltaTime;
            Debug.Log(powerTimer);
        }
        else
        {
            if (ballstate == false)
            {
                rollTimer = 1;
                ballstate = true;
            }
            
        }

        if (rollTimer > 0)
        {
            ballrb.velocity = new Vector3(ballXSpeed, 0, ballZSpeed);
            rollTimer = rollTimer - Time.deltaTime;
            powerOn = false;
            //Debug.Log(rollTimer);
        }
        else
        {
            if (ballstate == true)
            {
                ballrb.velocity = new Vector3(0, 0, 0);
                ballZSpeed = 0;
                ballXSpeed = 0;
                ballstate = false;
            }
        }

    }
}
