using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour, IAttachable
{
    public bool readyForDelivery;
    public void OnAttach()
    {
        //throw new System.NotImplementedException();
    }

    public IEnumerator WaitForDelivery()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void OnDettach()
    {
        if (readyForDelivery)
        {
            //zaczakaj chwile
            //grosza daj uiowi canvasem potrzasnij
            //zniszcz ciasteczko
            //wyswietl info ze rodzina jest szczesliwa
        }
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
