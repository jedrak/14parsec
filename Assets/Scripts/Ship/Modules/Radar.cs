using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour, IAttachable
{
    bool attached = false;
    public void OnAttach()
    {
        attached = true;
    }

    public void OnDettach()
    {
        attached = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
   
  
}
