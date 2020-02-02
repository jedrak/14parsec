using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsControler : MonoBehaviour
{
    [SerializeField]
    GameObject starsOBJ;

    Stars[][] stars;

    void Start()
    {
        stars = new Stars[3][];
        for (int i=0; i<3; i++)
        {
            stars[i] = new Stars[3];
            for (int j = 0; j < 3; j++)
            {
                GameObject pom = Instantiate(starsOBJ,new Vector3((j-1)*50, (i-1)*50, 0), Quaternion.identity);
                stars[i][j] = pom.GetComponent<Stars>();
                stars[i][j].SetParameters(this,i,j);
            }
        }
    }

    public void Move(int wiersz, int kolumna, Vector2 v)
    {
        if(v.x == 0)
        {
            if (v.y == -1)
            {
                wiersz = (wiersz + 1) % 3;
                Debug.Log("gora");
            }
            else
            {
                wiersz = (wiersz + 4) % 3;
                Debug.Log("dol");
            }
            for(int i=0;i<3;i++)
            {
                stars[wiersz][i].transform.position += (Vector3)v * (-150);
            }
        }
        else
        {
            if (v.x == -1)
            {
                kolumna = (kolumna + 1) % 3;
                Debug.Log("prawo");
            }
            else
            {
                kolumna = (kolumna + 4) % 3;
                Debug.Log("lewo");
            }
            for (int j = 0; j < 3; j++)
            {
                stars[j][kolumna].transform.position += (Vector3)v * (-150);
            }
        }
    }

    void Update()
    {
        
    }
}
