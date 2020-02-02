using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetSpawner : MonoBehaviour
{

    public List<Sprite> planetSprites;
    public GameObject planetPrefab;
    public Arrow arrow;
    public Stack<GameObject> planets;
    public List<GameObject> packeges;
    public int money;
    private CircleCollider2D coll;
    public TextMeshProUGUI moneyText;


    public void NewPlanet()
    {
        GameObject go = Instantiate(planetPrefab);
        Vector3 translate = new Vector3(Random.Range(-50, 50), Random.Range(-100, 100), 0.0f);
        go.transform.Translate(translate);
        go.GetComponent<SpriteRenderer>().sprite = planetSprites[Random.Range(0, planetSprites.Count - 1)];
        arrow.target = go.transform;
        planets.Push(go);
        Instantiate(packeges[Random.Range(0, packeges.Count - 1)], new Vector3(coll.offset.x, coll.offset.y, 0), Quaternion.identity, transform);
        coll.offset =  new Vector2(translate.x, translate.y);
        if (planets.Count > 1)
        {
            
            foreach (Cake cake in GetComponentsInChildren<Cake>())
            {
                Debug.Log(cake.name);
                cake.readyForDelivery = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        planets = new Stack<GameObject>();
        coll = GetComponent<CircleCollider2D>();
        //NewPlanet();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

             foreach (Cake cake in GetComponentsInChildren<Cake>())
            {
                //Debug.Log(cake.name);
                cake.readyForDelivery = true;
            }
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (Cake cake in GetComponentsInChildren<Cake>())
        {
            cake.readyForDelivery = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        moneyText.text = "x " + money;
    }
}
