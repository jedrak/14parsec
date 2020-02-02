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
    [SerializeField]
    float textOffSet = 0.1f;
    [SerializeField]
    RectTransform textTransform;
    [SerializeField]
    Text text;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPozycion = rectTransform.position;
        screenX = (Screen.width/2) * (1-distanceFromeBorder);
        screenY = (Screen.height/2) * (1-distanceFromeBorder);
    }

    void Update()
    {
        Vector3 direction = Direction();

        text.text = ((int)direction.magnitude).ToString() + " pc";

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