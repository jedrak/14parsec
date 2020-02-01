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
    [SerializeField]
    float maxSize = 1.5f;
    [SerializeField]
    float minSize = 0.7f;

    public Rigidbody2D rb;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Spawn(Vector3 direction)
    {
        // Prędkość (cross sprawia że nie lecą prosto w ciebie tylko +- "angle" w ciebie)
        Vector3 cross = Vector3.Cross(direction.normalized, Vector3.forward) * Random.Range(-angle,angle);
        //Debug.Log(rb.velocity);
        rb.velocity = (-direction + cross) * spead;

        // Ustawiamy losową prędkość obrotó
        rb.angularVelocity = 0;
        rb.AddTorque(Random.Range(minRotation, maxRotation));

        // Ustawiamy losową skale
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size, size, 0);
    }
} 