using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockManager : Singleton<DockManager>
{
    public Dock[] docks;
    public SpriteRenderer[] wires;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < docks.Length; i++)
        {
            docks[i].wire = wires[i];
        }
    }
}
