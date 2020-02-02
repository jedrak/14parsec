using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetRotate : MonoBehaviour
{
    void Update()
    {
        if(gameObject.GetComponent<RectTransform>() != null)
            gameObject.GetComponent<RectTransform>().Rotate(0, 0, 5 * Time.deltaTime);
        else
            transform.Rotate(0, 0, 2 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
