using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(-_rb.velocity / 15);
        //Debug.Log(_rb.velocity);
        Debug.DrawRay(transform.position, _rb.velocity);
    }
}
