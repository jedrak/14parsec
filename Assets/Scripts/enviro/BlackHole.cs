using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : SpawnAble
{
    [SerializeField]
    float strength = 2;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Czarna Dziura jest");
        if (collision.tag == "Meteor")
        {
            Vector2 direction = transform.position - collision.transform.position;
            collision.GetComponent<Rigidbody2D>().AddForce(direction.normalized * strength);
            Debug.Log("Czarna Dziura działa");
        }
    }

    public override void Spawn(Vector3 direction)
    {
        
    }
}
