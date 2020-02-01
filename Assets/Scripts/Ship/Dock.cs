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

    public void Attach(DockHandler item)
    {
        wire.enabled = true;
        this.item = item;
        item.GetComponent<IAttachable>().OnAttach();
        ///////////////////
        audio.Play();
    }

    public void Dettach()
    {
        wire.enabled = false;
        item.GetComponent<IAttachable>().OnDettach();
        this.item = null;
    }

    public bool Docked()
    {
        return item != null;
    }





    // Start is called before the first frame update
    void Start()
    {
        wire = GetComponentInChildren<SpriteRenderer>();
        wire.enabled = false;
        //////////////////
        audio = GetComponent<AudioSource>();
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
