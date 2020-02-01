using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulSpawn : SpawnAble
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Spawn(Vector3 direction)
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }
}
