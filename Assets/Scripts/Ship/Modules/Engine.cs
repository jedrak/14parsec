using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : DockHandler
{
    [Range(0.0f, 1.0f)]
    public float force;
    public override void OnAttach()
    {
        //transform.parent = _dock.transform;
        Vector3 buff = transform.localRotation * (new Vector3(0, 1, 0));
        Debug.DrawRay(transform.position, buff);
        _dock.GetComponentsInParent<Rigidbody2D>()[0].AddForceAtPosition((buff*force) , new Vector2(transform.position.x, transform.position.y));
    }

    public override void OnDettach()
    {
        Vector3 buff = transform.localRotation * (new Vector3(0, -1, 0));
        _dock.GetComponentsInParent<Rigidbody2D>()[0].AddForceAtPosition((buff * force), new Vector2(transform.position.x, transform.position.y));
    }

}
