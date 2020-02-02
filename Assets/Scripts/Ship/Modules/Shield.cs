using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IAttachable
{
    private PolygonCollider2D coll;
    AudioSource audio;

    public void OnAttach()
    {
        if(coll.enabled == false)
        {
            audio.Play();
        }
        coll.enabled = true;
    }

    public void OnDettach()
    {
        coll.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<PolygonCollider2D>();
        coll.enabled = false;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
