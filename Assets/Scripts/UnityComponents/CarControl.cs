﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform carTransform;
    private Rigidbody2D carRigidbody;
    public Vector2 SpeedGain;
    public float MaxSpeed;

    public GameObject front;
    private Transform frontTransform;

    void Start()
    {
        carTransform = GetComponent<Transform>();
        carRigidbody = GetComponent<Rigidbody2D>();
        frontTransform = front.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(carTransform.position);

        if(tag != "DeadCar")
        {
            if (Input.GetKey(KeyCode.W))
            {
                carRigidbody.AddForce(carTransform.up * 6.5f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                carRigidbody.AddForce(-carTransform.up * 4f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                carRigidbody.rotation += 0.3f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                carRigidbody.rotation -= 0.3f;
            }
        }        
    }
}