using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour, IAttachable
{
    public bool readyForDelivery;
    private PlanetSpawner _ps;
    public void OnAttach()
    {
        //throw new System.NotImplementedException();
    }

    public IEnumerator WaitForDelivery()
    {
        yield return new WaitForSeconds(3.0f);
        readyForDelivery = false;
        Destroy(gameObject);
    }

    public void OnDettach()
    {
        if (readyForDelivery)
        {
            StartCoroutine(WaitForDelivery());

        }
    }


    private void OnDestroy()
    {
        //grosza daj uiaowi cnavasem potrzasnij
        _ps.money++;
        Debug.Log(_ps.money);
    }
    // Start is called before the first frame update
    void Start()
    {
        _ps = GetComponentInParent<PlanetSpawner>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
