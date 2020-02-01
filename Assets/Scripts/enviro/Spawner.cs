using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject prifab;
    [SerializeField]
    int maxCount = 10;

    [SerializeField]
    float range = 10;
    [SerializeField]
    float[] timeToNextSpawn = { 1, 0, 3, 2, 1, 2 };

    GameObject[] list;
    SpawnAble[] spawnAble;
    float time = 0;

    void Start()
    {
        list = new GameObject[maxCount];
        spawnAble = new SpawnAble[maxCount];
        for(int i=0; i<maxCount; i++)
        {
            list[i] = GameObject.Instantiate(prifab, new Vector3(100,100,100), Quaternion.identity,null);
            spawnAble[i] = list[i].GetComponent<SpawnAble>();
        }
        ResetTime();
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            ResetTime();
            Spawn();
        }
    }

    void Spawn()
    {
        Vector2 direction = new Vector2(Random.value-0.5f, Random.value - 0.5f);
        direction = direction.normalized * range;
        int maxIndex = FindFarthest();
        list[maxIndex].transform.position = transform.position + (Vector3)direction;
        spawnAble[maxIndex].Spawn((Vector3)direction);
    }

    int FindFarthest()
    {
        int maxIndex = 0;
        float maxDistance = Vector2.Distance(transform.position,list[0].transform.position);
        for(int i = 1; i < list.Length; i++)
        {
            float distance = Vector2.Distance(transform.position, list[0].transform.position);
            if (Vector2.Distance(transform.position, list[maxIndex].transform.position) < Vector2.Distance(transform.position, list[i].transform.position))
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    void ResetTime()
    {
        int rand = Random.RandomRange(0, timeToNextSpawn.Length - 1);
        time = timeToNextSpawn[rand];
    }
}
