using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject LifePickupGO;
    float spawnInterval = 30.0f; 

    void Start()
    {
        InvokeRepeating("SpawnPickup", 0f, spawnInterval); 
    }

    void Update()
    {
        
    }

    void SpawnPickup()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        
        Vector2 spawnPosition = new Vector2(Random.Range(min.x, max.x), max.y);
        Instantiate(LifePickupGO, spawnPosition, Quaternion.identity);
    }
}
