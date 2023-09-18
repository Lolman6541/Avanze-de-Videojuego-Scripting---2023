using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGO;
    float maxSpawnRateInSeconds = 5f;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1, 1));

        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextEnemySpawn ();

    }
    void ScheduleNextEnemySpawn()
    {
        float spawnInNseconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNseconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else 
           spawnInNseconds = 1f;

           Invoke("SpawnEnemy", spawnInNseconds);

    }
    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f)
         maxSpawnRateInSeconds--;

        if(maxSpawnRateInSeconds == 1f)
        CancelInvoke("IncreaseSpawnRate");
    }
    public void ScheduleEnemySpawner()
    {
       Invoke("SpawnEnemy", maxSpawnRateInSeconds);
       InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }
     
    public void UnScheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }

}