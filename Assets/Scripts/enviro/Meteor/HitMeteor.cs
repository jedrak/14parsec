using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMeteor : MonoBehaviour
{
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
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
            // ZDERZENIE Z STATKIEM
            //audio.Play();
        }
    }
}
