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
                stars[i][j].name = "Stars (" + i.ToString() + ", " + j.ToString() + ")";
            }
        }
    }

    public void Move(int wiersz, int kolumna, Vector2 v)
    {
        Debug.Log(v);
        if(v.x == 0)
        {
            if (v.y < 0)
            {
                wiersz = (wiersz + 1) % 3;
                
            }
            else
            {
                wiersz = (wiersz + 2) % 3;
                
            }
            Debug.Log("wiersz: "+wiersz);
            for (int i=0;i<3;i++)
            {
                stars[wiersz][i].transform.position += (Vector3)v * (150);
            }
        }
        else
        {
            if (v.x < 0)
            {
                kolumna = (kolumna + 1) % 3;
                Debug.Log("Kolumna: " + kolumna + "++");
            }
            else
            {
                kolumna = (kolumna + 2) % 3;
                Debug.Log("Kolumna: " + kolumna + "--");
            }
            for (int j = 0; j < 3; j++)
            {
                stars[j][kolumna].transform.position += (Vector3)v * (150);
            }
        }
    }

    void Update()
    {
        
    }
}
