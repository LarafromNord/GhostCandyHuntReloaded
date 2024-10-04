using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public CandyController candyToSpawn;

    void Start()
    {
        SpawnCandy(90);
    }

    void SpawnCandy(int candiesToSpawn)
    {
        for (int i = 0; i < candiesToSpawn; i++)
        {
            Instantiate(candyToSpawn);
            candyToSpawn.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-2.5f, 10));
        }
    }
}
