using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

public class EnemyPooler : MonoBehaviour
{

    public static EnemyPooler Instance;

    private void Awake()
    {
        Instance = this;
    }


    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> poolsList;

    public Dictionary<string, Queue<GameObject>> poolDictionaryQueue;
    
    void Start()
    {
        poolDictionaryQueue = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in poolsList)
        {
            Queue<GameObject> enemyPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject enemy = Instantiate(pool.prefab);
                enemy.SetActive(false);
                enemyPool.Enqueue(enemy);
            }
            poolDictionaryQueue.Add(pool.tag, enemyPool);
        }
        
        
    }

    public GameObject SpawnFromPool(String tag, Vector3 position)
    {
        if (!poolDictionaryQueue.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesnt exist in the pool dictionary");
            return null;
        }
        if (poolDictionaryQueue[tag].Count == 0)
        {
            return null;
        }

        GameObject enemyToSpawn = poolDictionaryQueue[tag].Dequeue();

        EnemyController enemyController = enemyToSpawn.GetComponent<EnemyController>();
        
        if (enemyController.isEnemyEnabled)
        {
            enemyToSpawn.SetActive(true);
            
            enemyController.setCurretHitPoints(enemyController.hitPoints);
            enemyController.isAlive = true;
                
            enemyToSpawn.transform.position = position;
            return enemyToSpawn;
        }

        return null;
    }

    public void enqueueEnemy(GameObject enemy)
    {
       poolDictionaryQueue[enemy.GetComponent<EnemyController>().enemyName].Enqueue(enemy);
    }
}
