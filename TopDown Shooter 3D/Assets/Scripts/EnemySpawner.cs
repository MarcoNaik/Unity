using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private float spawnCounter;
    private Vector3 spawnLocation;
    private EnemyPooler pooler;

    private void Start()
    {
        pooler = EnemyPooler.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        
        spawnLocation =  new Vector3(Random.Range(-20.0f, 20.0f), 10, Random.Range(-15.0f, 15.0f));
        
        pooler.SpawnFromPool("Slime", spawnLocation);
        
        spawnLocation =  new Vector3(Random.Range(-20.0f, 20.0f), 10, Random.Range(-15.0f, 15.0f));
        
        pooler.SpawnFromPool("Azulito", spawnLocation);

        
    }

    
    
    
}
