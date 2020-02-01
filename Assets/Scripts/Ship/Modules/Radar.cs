using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour, IAttachable
{
    public bool attached = false;
    public void OnAttach()
    {
        attached = true;
    }

    public void OnDettach()
    {
        attached = false;
    }

    // Start is called before the first frame update
  
}
