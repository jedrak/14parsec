﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IAttachable
{

    void OnAttach();
    void OnDettach();
   
   
}

public class Engine : MonoBehaviour, IAttachable
{
    [Range(0.0f, 1.0f)]
    public float force;
    public void OnAttach()
    {
        //transform.parent = _dock.transform;
        Vector3 buff = transform.localRotation * (new Vector3(0, 1, 0));
        //Debug.DrawRay(transform.position, buff);
        GetComponent<DockHandler>()._dock.GetComponentsInParent<Rigidbody2D>()[0].AddForceAtPosition((buff*force) , new Vector2(transform.position.x, transform.position.y));
    }

    public void OnDettach()
    {
        //Debug.Log(GetComponent<DockHandler>()._dock.name);
        Vector3 buff = transform.localRotation * (new Vector3(0, -1, 0));
        //GetComponent<DockHandler>()._dock.GetComponentsInParent<Rigidbody2D>()[0].AddForceAtPosition((buff * force), new Vector2(transform.position.x, transform.position.y));
    }

}
