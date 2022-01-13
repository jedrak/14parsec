using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : SpawnAble
{
    [SerializeField]
    float strength = 2;
    [SerializeField]
    float maxVolume = 0.5f;
    [SerializeField]
    float rangeStart = 4;
    [SerializeField]
    float rangeStop = 2;

    AudioSource audio;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SpawnAble>() != null)
        {
            Vector2 direction = transform.position - collision.transform.position;
            collision.GetComponent<Rigidbody2D>().AddForce(direction.normalized * strength);

        }
        else if (collision.gameObject.GetComponent<ShipMove>() != null)
        {
            Vector2 direction = transform.position - collision.transform.position;
            collision.GetComponent<Rigidbody2D>().AddForce(direction.normalized * strength);

            audio.volume = (1 - ((maxVolume*(direction.magnitude-rangeStop))/(rangeStart-rangeStop))) * maxVolume;
        }
    }

    public override void Spawn(Vector3 direction)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ShipMove>() != null)
        {
            audio.volume = 0;
        }
    }
}
