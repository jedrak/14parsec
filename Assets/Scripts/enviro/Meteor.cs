using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SpawnAble
{
    [SerializeField]
    float angle = 15;
    [SerializeField]
    float spead = 0.3f;
    [SerializeField]
    float maxRotation = 5;
    [SerializeField]
    float minRotation = 2;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Spawn(Vector3 direction)
    {
        Vector3 cross = Vector3.Cross(direction.normalized, Vector3.forward) * Random.Range(-angle,angle);
        rb.velocity = (-direction + cross) * spead;
        rb.AddTorque(Random.Range(minRotation, maxRotation));
    }
}
