using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    private GameObject ship;


    private void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, ship.transform.position, Time.deltaTime*1.5f);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
