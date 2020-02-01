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


    public void Attach(DockHandler item)
    {
        this.item = item;
    }

    public void Dettach()
    {
        this.item = null;
    }

    public bool Docked()
    {
        return item != null;
    }



    public void Rot()
    {
        item.transform.rotation = transform.rotation;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Docked())
        {
            item.transform.position = transform.position;
            item.transform.rotation = transform.rotation;
            //Debug.Log(gameObject.name, this);
        }
    }
}
