using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform carTransform;
    private Transform victimTransform;
    private Rigidbody2D victimRigidbody;
    public float speed = 1.4f;

    private double distance;
    private Vector2 carDirection;

    void Start()
    {
        carTransform = carTransform.GetChild(0).transform;
        victimTransform = GetComponent<Transform>();
        victimRigidbody = GetComponent<Rigidbody2D>();
        distance = 6;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Math.Sqrt(Math.Pow(victimTransform.position.y - carTransform.position.y, 2) + Math.Pow(victimTransform.position.x - carTransform.position.x, 2));
        //carDirection = new Vector2(victimTransform.position.y - carTransform.position.y, victimTransform.position.x - carTransform.position.x);
        carDirection = (carTransform.position - transform.position).normalized;
        
        if (distance < 5)
        {
            victimRigidbody.AddForce(-carDirection * speed);
        }

        //Debug.Log(distance);
    }
}
