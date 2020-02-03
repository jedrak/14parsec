using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{

    public bool _isDraged { get; private set; }
    public float treshold;
    private Rigidbody2D _rb;
    private DockHandler _nearest = null;
    private BoxCollider _collider;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider>();
        _collider.size = new Vector3(Screen.width/112.0f, Screen.height/112.0f, 0);
    }


    private void OnMouseDown()
    {
        DockHandler[] dockHandlers =  GameObject.FindObjectsOfType<DockHandler>();
        _nearest = null;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse = new Vector3(mouse.x, mouse.y, 0);
        float nearstDistance = treshold, distance;
        foreach(var dockHandler in dockHandlers)
        {
            distance = Vector3.Distance(mouse, dockHandler.transform.position);
            if (distance < nearstDistance)
            {
                _nearest = dockHandler;
                nearstDistance = distance;
            }
            //Debug.Log(dockHandler.name + " " + Vector3.Distance(mouse, dockHandler.transform.position));
        }

       
        //Debug.Log(_nearest.name);
       
    }
    private void OnMouseDrag()
    {
        if(_nearest != null)
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse = new Vector3(mouse.x, mouse.y, 0);
            _nearest.transform.position = mouse;
        }
        //_isDraged = true;
        //Vector3 buff = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ///transform.position = new Vector3(buff.x, buff.y, 0);
        //Debug.Log(transform.position);
    }

   


    private void OnMouseUp()
    {
        _nearest = null;
        //_isDraged = false;
    }

    private void Update()
    {

    }
}
