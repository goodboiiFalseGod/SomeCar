using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureForces : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform Transform;
    private Rigidbody2D Rigidbody;

    private Vector2 Velocity;
    private Transform frontTransform;

    void Start()
    {
        Transform = GetComponent<Transform>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Velocity = Rigidbody.velocity;

        Rigidbody.AddForce(-Velocity * 0.3f);
    }
}
