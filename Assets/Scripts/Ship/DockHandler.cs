using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockHandler : MonoBehaviour
{
    private DragDrop _dragDrop; 
    [SerializeField]
    private Dock _dock = null;
    void Start()
    {
        _dragDrop = GetComponent<DragDrop>();
    }


    private void OnMouseUp()
    {
        float minimalDistance = 3.0f;
        foreach(Dock dock in FindObjectsOfType<Dock>()) 
        {
            if (DistanceToDock(dock) < minimalDistance)
            {
                minimalDistance = DistanceToDock(dock);
                _dock = dock;
            }
        }    
    }

    public float DistanceToDock(Dock dock)
    {
        return Vector3.Distance(transform.position, dock.transform.position);
    }
}
