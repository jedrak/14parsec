using System.Collections;
using System.Collections.Generic;
using UnityEngine;



interface IDocable
{
    void Attach(DockHandler item);
    void Dettach();
    bool Docked();
    
}
public class Dock : MonoBehaviour, IDocable
{
    [SerializeField]
    private DockHandler item = null;
    private SpriteRenderer wire;
    //////////////////
    private AudioSource audio;
    [SerializeField]
    private AudioClip dettachMP3;
    private AudioClip attachMP3;
    //\\\\\\\\\\\\\\\\

    public void Attach(DockHandler item)
    {
        wire.enabled = true;
        ///////////////////
        if(Docked() == false)
        {
            audio.clip = attachMP3;
            Play();
        }
        //\\\\\\\\\\\\\\\\\
        this.item = item;
        item.GetComponent<IAttachable>().OnAttach();
        
    }

    public void Dettach()
    {
        wire.enabled = false;
        item.GetComponent<IAttachable>().OnDettach();
        ///////////////////
        if (Docked() == false)
        {
            audio.clip = dettachMP3;
            Play();
        }
        //\\\\\\\\\\\\\\\\\
        this.item = null;
    }

    public bool Docked()
    {
        return item != null;
    }

    void Play()
    {
        if (audio.isPlaying == false)
        {
            audio.Play();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        wire = GetComponentInChildren<SpriteRenderer>();
        wire.enabled = false;
        //////////////////
        audio = GetComponent<AudioSource>();
        attachMP3 = audio.clip;
        //\\\\\\\\\\\\\\\\
    }

    // Update is called once per frame
    void Update()
    {
        if (Docked())
        {
            if(item.freezePos) item.transform.position = transform.position;
            item.transform.rotation = transform.rotation;
            //Debug.Log(gameObject.name, this);
        }

    }
}
