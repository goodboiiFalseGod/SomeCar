using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform victimTransform;
    private Rigidbody2D victimRigidbody;

    public int Health = 100;

    void Start()
    {
        victimTransform = GetComponent<Transform>();
        victimRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float p = collision.relativeVelocity.magnitude;

            Health -= (int)p * 8;

            //Debug.Log(p);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(Health <= 0)
        {
            Vector3 newSpawn = new Vector3(Random.Range(-18, 18), Random.Range(-18, 18), 0);
            victimTransform.position = newSpawn;
            victimRigidbody.velocity = new Vector2(0, 0);

            Health = 100;

            tag = "Dead";
        }
    }
}
