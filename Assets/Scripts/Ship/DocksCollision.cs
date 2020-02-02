using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocksCollision : MonoBehaviour
{
    [Range(0.0f, 0.5f)]
    public float speed;
    [Range(2, 5)]
    public int maxNumber;
    Dock[] docks;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.Play();

        docks = GetComponentsInChildren<Dock>();
        int numOfDestroyedModules = Random.Range(1, maxNumber);
        for(int i = 0; i < maxNumber; i++)
        {
            int rand = Random.Range(0, docks.Length - 1);
            if (docks[rand].item != null)
            {
                DockHandler buff = docks[rand].item;
                docks[rand].Dettach();
                buff.GetComponent<DockHandler>().StartCoroutine("BlinkEnable");
                buff.GetComponent<Rigidbody2D>().velocity = buff.transform.localPosition * (new Vector2(1, 1) * speed * 0.01f);
                Debug.Log(buff.GetComponent<Rigidbody2D>().velocity);
                
                
            }
                
            
        }
    }
}
