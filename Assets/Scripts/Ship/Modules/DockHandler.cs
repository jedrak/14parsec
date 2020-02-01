﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockHandler : MonoBehaviour
{
    [Range(0.0f, 2.0f)]
    public float minimalDistance;
    private DragDrop _dragDrop; 
    [SerializeField]
    public Dock _dock { get; private set; } = null;
    public bool freezePos; 
    void Start()
    {
        _dragDrop = GetComponent<DragDrop>();
    }


    private void OnMouseUp()
    {


        freezePos = true;
       
    }

    public void FindNearest()
    {
        float distance = minimalDistance;
        foreach (Dock dock in FindObjectsOfType<Dock>())
        {
            if (DistanceToDock(dock) < distance)
            {
                distance = DistanceToDock(dock);
                _dock = dock;
            }
        }
        if (_dock != null)
        {
            _dock.Attach(this);
            //Debug.Log(_dock.name);

            if (DistanceToDock(_dock) > minimalDistance)
            {
                _dock.Dettach();
                _dock = null;
            }

        }
    }



    private void OnMouseDown()
    {
        if(_dock != null)
        {
            _dock.Dettach();
        }
        _dock = null;
        freezePos = false;
        
    }

    public float DistanceToDock(Dock dock)
    {
        return Vector3.Distance(transform.position, dock.transform.position);
    }

    private void Update()
    {
        FindNearest();
        
    }
}
