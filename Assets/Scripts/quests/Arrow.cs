using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    Transform ship;
    [SerializeField]
    float distanceFromeBorder = 0.1f;

    Vector3 startPozycion;
    float screenX;
    float screenY;
    RectTransform rectTransform;
    Image image;
    bool acttive = true;

    [SerializeField]
    float textOffSet = 0.1f;
    [SerializeField]
    RectTransform textTransform;
    [SerializeField]
    Text text;
    [SerializeField]
    float distanceScale = 80;
    [SerializeField]
    int precyzion = 2;
    [SerializeField]
    float planetaSize = 12;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        startPozycion = rectTransform.position;
        screenX = (Screen.width/2) * (1-distanceFromeBorder);
        screenY = (Screen.height/2) * (1-distanceFromeBorder);

        precyzion = (int)Mathf.Pow(10, precyzion);
    }

    void Update()
    {
        Vector3 direction = Direction();
        float parsec = (direction.magnitude - planetaSize) * distanceScale;
        parsec = (int)parsec;

        if(parsec>0)
        {
            text.text = (parsec / precyzion).ToString() + " pc";
            if(acttive == false)
            {
                acttive = true;
                image.enabled = true;
            }
        }
        else
        {
            if(acttive == true)
            {
                text.text = " ";
                acttive = false;
                image.enabled = false;
            }
        }
        

        if (Mathf.Abs(direction.x/direction.y) > screenX/screenY)
        {
            direction = direction * (screenX / Mathf.Abs(direction.x));
        }
        else
        {
            direction = direction * (screenY / Mathf.Abs(direction.y));
        }

        rectTransform.position = direction + startPozycion;
        textTransform.position = (1 - textOffSet) * (direction) + startPozycion;
        rectTransform.eulerAngles = Vector3.forward * Vector3.SignedAngle(direction, Vector3.up, Vector3.back);
    }

    Vector3 Direction()
    {
        return target.position - ship.position;//+ new Vector3(600,314,0);
    }
}