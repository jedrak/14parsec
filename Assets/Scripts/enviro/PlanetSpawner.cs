using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{

    public List<Sprite> planetSprites;
    public GameObject planetPrefab;
    public Arrow arrow;
    public Stack<GameObject> planets;
    private CircleCollider2D coll;


    public void NewPlanet()
    {
        GameObject go = Instantiate(planetPrefab);
        Vector3 translate = new Vector3(Random.Range(-50, 50), Random.Range(-100, 100), 0.0f);
        go.transform.Translate(translate);
        go.GetComponent<SpriteRenderer>().sprite = planetSprites[Random.Range(0, planetSprites.Count - 1)];
        arrow.target = go.transform;
        planets.Push(go);
        coll.offset =  new Vector2(translate.x, translate.y);
        //Debug.Log(coll.offset);
    }
    // Start is called before the first frame update
    void Start()
    {
        planets = new Stack<GameObject>();
        coll = GetComponent<CircleCollider2D>();
        NewPlanet();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewPlanet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
