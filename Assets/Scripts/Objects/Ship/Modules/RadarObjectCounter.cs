using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarObjectCounter : MonoBehaviour
{

    private Material material;
    
    public int counterModules = 0;
    public int counterObstacles = 0;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IAttachable>() != null) counterModules++;
        if (collision.gameObject.GetComponent<SpawnAble>() != null) counterObstacles++;
        SetColor();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IAttachable>() != null) counterModules--;
        if (collision.gameObject.GetComponent<SpawnAble>() != null) counterObstacles--;
        SetColor();
    }

    public void SetColor()
    {
        if (GetComponentInParent<Radar>().attached)
        {
            if (counterModules > 0)
            {
                material.SetColor("_EmissionColor", new Color(1f, 0.5f, 0f) * 3f);
            }
            else if (counterObstacles > 0)
            {

                material.SetColor("_EmissionColor", new Color(0.24f, 0.55f, 0.6f) * 3f);
            }
            else
            {
                material.SetColor("_EmissionColor", new Color(3f, 0f, 1.2f) * 1.5f);
            }
        }
    }
}
