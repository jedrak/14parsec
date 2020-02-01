using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IAttachable
{
    private PolygonCollider2D coll;
    public void OnAttach()
    {
        coll.enabled = true;
    }

    public void OnDettach()
    {
        coll.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<PolygonCollider2D>();
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
