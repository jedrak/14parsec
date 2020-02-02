using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    [SerializeField]
    StarsControler stars;

    private Rigidbody2D _rb;

    public float maxVelocity;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.AddForce(-_rb.velocity / 15);
        //Debug.Log(_rb.velocity);
        Debug.DrawRay(transform.position, _rb.velocity);
    }

    public void BlackHole(Vector3 direction)
    {
        stars.BlackHole(direction);
    }
}
