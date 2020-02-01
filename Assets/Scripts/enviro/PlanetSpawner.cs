using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{

    public List<Sprite> planetSprites;
    public GameObject planetPrefab;
    public Arrow arrow;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(planetPrefab);
        Vector3 translate = new Vector3(Random.Range(-50, 50), Random.Range(-100, 100), 0.0f);
        go.transform.Translate(translate);
        go.GetComponent<SpriteRenderer>().sprite = planetSprites[Random.Range(0, planetSprites.Count - 1)];
        arrow.target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
