using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMeteor : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] ParticleSystem meteorParticle;
    [SerializeField] ParticleSystem aircraftParticle;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(meteorParticle, collision.contacts[0].point, Quaternion.identity);
        if(collision.gameObject.GetComponent<Meteor>() != null)
        {
            // ZDERZENIE METEOROW
        }
        else if (collision.gameObject.GetComponent<IAttachable>() != null)
        {
            // ZDERZENIE Z MODOLEM
        }
        else if (collision.gameObject.GetComponent<ShipMove>() != null)
        {
            Instantiate(aircraftParticle, collision.contacts[0].point, Quaternion.identity);
            // ZDERZENIE Z STATKIEM
            //audio.Play();
        }
    }
}
