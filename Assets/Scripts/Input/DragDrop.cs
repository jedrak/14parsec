using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    public Vector3 startSpeed, acceleration;
    public bool _isDraged { get; private set; }
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        _isDraged = true;
        Vector3 buff = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(buff.x, buff.y, 0);
    }

    private void OnMouseUp()
    {
        _isDraged = false;
    }

    private void Update()
    {

    }

}
