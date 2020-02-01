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
    int startCount = 2;

    [SerializeField]
    float spawnRange = 10;
    [SerializeField]
    float outRange = 10;
    [SerializeField]
    float prepareTime = 0;
    [SerializeField]
    float[] timeToNextSpawn = { 1, 0, 3, 2, 1, 2 };

    GameObject[] list;
    SpawnAble[] spawnAble;
    float time = 0;

    void Start()
    {
        time = prepareTime;
        list = new GameObject[maxCount];
        spawnAble = new SpawnAble[maxCount];
        for(int i=0; i<maxCount; i++)
        {
            list[i] = GameObject.Instantiate(prifab, new Vector3(100,100,100), Quaternion.identity,null);
            spawnAble[i] = list[i].GetComponent<SpawnAble>();
        }
        for(int i=0; i<startCount; i++)
        {
            Spawn();
        }
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
        direction = direction.normalized * spawnRange;
        int maxIndex = FindFarthest();
        if(Vector2.Distance(transform.position, list[maxIndex].transform.position) > outRange)
        {
            list[maxIndex].transform.position = transform.position + (Vector3)direction;
            spawnAble[maxIndex].Spawn((Vector3)direction);
        }
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
