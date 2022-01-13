using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterBlackHole : MonoBehaviour
{
    [SerializeField]
    float distance = 150;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<BlackHole>() == null)
        {
            Vector3 direction = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
            direction = direction.normalized * distance;
            collision.transform.position += direction;
            if(collision.GetComponent<ShipMove>() != null)
            {
                collision.GetComponent<ShipMove>().BlackHole(collision.transform.position);
            }
        }
    }
}
