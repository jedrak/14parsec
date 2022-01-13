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
    [HideInInspector] public SpriteRenderer wire;
    public DockHandler item { get; private set; } = null;


    void Start()
    {
        wire.enabled = false;
    }

    void Update()
    {
        if(Docked())
        {
            if(item.freezePos)
                item.transform.position = transform.position;
            item.transform.rotation = transform.rotation;
        }
    }

    public void Attach(DockHandler item)
    {
        wire.enabled = true;
        if(Docked() == false)
        {
            StartCoroutine(CamShake.instance.Shake(.01f, .05f));
            AudioManager.instance.PlaySound(AudioStorage.SoundList["AttachingModule"], transform.position);

        }
        this.item = item;
        item.GetComponent<IAttachable>().OnAttach();
        
    }

    public void Dettach()
    {
        wire.enabled = false;
        
        if (Docked() == true)
        {
            item.GetComponent<IAttachable>().OnDettach();
            AudioManager.instance.PlaySound(AudioStorage.SoundList["DetachingModule"], transform.position);
        }
        this.item = null;
    }

    public bool Docked()
    {
        return item != null;
    }
}
