using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour, IAttachable
{
    public bool attached = false;
    AudioSource audio;

    public void OnAttach()
    {
        if(attached == false)
        {
            audio.Play();
        }
        attached = true;
    }

    public void OnDettach()
    {
        if (attached == true)
        {
            audio.Stop();
        }
        attached = false;
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
  
}
