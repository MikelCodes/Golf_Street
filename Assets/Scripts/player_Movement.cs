using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    public float speed = 10.0f;
    private float translation;
    private float straife;
    //-------------------------------------
    private GameObject ball;
    private Rigidbody ballrb;
    private float ballXSpeed;
    private float ballZSpeed;
    private float rollTimer;
    //-------------------------------------
    public AudioSource ballAudio;

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


        if (Input.GetAxis("Vertical") == 1)
        {
            ballZSpeed = 10;
        }
        if (Input.GetAxis("Vertical") == -1)
        {
            ballZSpeed = -10;
        }
        if (Input.GetAxis("Horizontal") == 1)
        {
            ballXSpeed = 10;
        }
        if (Input.GetAxis("Horizontal") == -1)
        {
            ballXSpeed = -10;
        }

        if (Input.GetKeyDown("p") && rollTimer <= 0)
        {
            rollTimer = 0.5f;
            //Debug.Log(rollTimer);
            //------------------------------------------------------------
            ballAudio.Play();
        }

        if (rollTimer > 0)
        {
            ballrb.velocity = new Vector3(ballXSpeed, -1, ballZSpeed);
            rollTimer = rollTimer - Time.deltaTime;
            //Debug.Log(rollTimer);
        }
        else
        {
            ballrb.velocity = new Vector3(0, -1, 0);  
        }

        speedReset();

    }

    private void speedReset()
    {
        ballXSpeed = 0;
        ballZSpeed = 0;
    }
}
