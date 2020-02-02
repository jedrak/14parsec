using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    StarsControler controler;
    int wiersz, kolumna;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ShipMove>() != null)
        {
            Vector3 direction = collision.transform.position - transform.position;
            float angle = Vector3.SignedAngle(direction, Vector3.up, Vector3.back);

            if (angle > 45 && angle < 135)          controler.Move(wiersz, kolumna, Vector2.left);
            else if (angle < -45 && angle > -135)   controler.Move(wiersz, kolumna, Vector2.right);
            else if (angle > -45 && angle < 45)     controler.Move(wiersz, kolumna, Vector2.up);
            else if (angle > 135 || angle < -135)   controler.Move(wiersz, kolumna, Vector2.down);
        }
    }



    public void SetParameters(StarsControler starsControler,int i, int j)
    {
        controler = starsControler;
        wiersz = i;
        kolumna = j;
    }
}
