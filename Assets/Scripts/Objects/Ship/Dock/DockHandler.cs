using System.Collections;
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


    private void Update()
    {
        FindNearest();
    }

    private void OnMouseUp()
    {
        freezePos = true;
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

            if (DistanceToDock(_dock) > minimalDistance)
            {
                _dock.Dettach();
                _dock = null;
            }

        }
    }

    public IEnumerator BlinkEnable()
    {
        enabled = false;
        yield return new WaitForSeconds(.1f);
        enabled = true;
    }

    public float DistanceToDock(Dock dock)
    {
        return Vector3.Distance(transform.position, dock.transform.position);
    }
}
