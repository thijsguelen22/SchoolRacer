﻿using UnityEngine;
using System.Collections;

public class UnityUIController : MonoBehaviour
{
    public float speed = 10.0f;
    private bool walkUp;
    //private bool walkLeft;
    //private bool walkRight;
    private bool walkDown;

    private Vector3 velocity;

    public float forwardSpeed = 3.0f;
    public float backwardSpeed = 2.0f;
    public bool ready;
    public bool pause = false;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        //if (walkUp == true && ready == true) waarom dit zo staat weet ik niet maar het werkt dus STFU
        if (walkUp == true && ready == true && pause == false)
        {
            if (pause == false)
            {
                var locVel = transform.InverseTransformDirection(rb.velocity);
                //locVel.z = forwardSpeed;
                locVel.z = forwardSpeed * 0.1f; //werdt meer velocity powered race dan wat anders xd
                //rb.velocity = transform.TransformDirection(locVel);
                //rb.MovePosition(transform.position + transform.forward * Time.deltaTime * forwardSpeed * 10000000);
                //rb.MovePosition(transform.position + transform.forward * (1000000000000 * 10000000000000));
                rb.AddForce(transform.forward * forwardSpeed);
            }
        }
        else if (walkDown == true && ready == true)
        {
            if (pause == false)
            {
                var locVel = transform.InverseTransformDirection(rb.velocity);
                locVel.z = (backwardSpeed * -1);
                rb.velocity = transform.TransformDirection(locVel);
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * (backwardSpeed * -1));
            }
        }
        if (ready == true)
        {
            float v = Input.GetAxis("Vertical");
            //rb.MovePosition(transform.position + transform.forward * Time.deltaTime * backwardSpeed * v * 5);
            rb.AddForce(transform.forward * forwardSpeed * v);
        }
    }
    public void PlayerWalkUp(int value)
    {
        if (value == 1)
        {
            walkUp = true;
        }
        else
        {
            walkUp = false;
        }

    }

    /*public void PlayerWalkLeft(int value)
    {
        if (value == 1)
        {
            walkLeft = true;
        }
        else
        {
            walkLeft = false;
        }

    }

    public void PlayerWalkRight(int value)
    {
        if (value == 1)
        {
            walkRight = true;
        }
        else
        {
            walkRight = false;
        }

    }*/

    public void PlayerWalkDown(int value)
    {
        if (value == 1)
        {
            walkDown = true;
        }
        else
        {
            walkDown = false;
        }

    }
}