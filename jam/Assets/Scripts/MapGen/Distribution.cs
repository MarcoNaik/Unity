using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using Random = UnityEngine.Random;

public class Distribution : MonoBehaviour
{
    public Distribution(GameObject defaultPrefab, List<Prefabs> prefabsToConsider)
    {
        this.defaultPrefab = defaultPrefab;
        this.prefabsToConsider = prefabsToConsider;
    }

    [System.Serializable]
    public class Prefabs
    {
        public Prefabs(GameObject prefab, int perentage, int quantity)
        {
            this.prefab = prefab;
            this.perentage = perentage;
            this.quantity = quantity;
        }

        public GameObject prefab;
        public int perentage;
        public int quantity;
    }

    public GameObject defaultPrefab;

    public List<Prefabs> prefabsToConsider;

    public List<Prefabs> GetPrebList()
    {
        List<Prefabs> backUpList = new List<Prefabs>();
        foreach (Prefabs p in prefabsToConsider)
        {
            backUpList.Add(new Prefabs(p.prefab,p.perentage,p.quantity));
        }

        return backUpList;
    }

    public void SetPrefabList(List<Prefabs> list)
    {
        prefabsToConsider = list;
    }
    

    public GameObject PickByPercentage()
    {
        int randomNumber = Random.Range(1, 101);
        int accumulatedProbability = 0;

        foreach (Prefabs p  in prefabsToConsider)
        {
            accumulatedProbability += p.perentage;
            if (randomNumber <= accumulatedProbability) return p.prefab;
        }

        return defaultPrefab;
    }

    public GameObject PickByQuantity(int mapSize)
    {
        Debug.Log(mapSize);
        int quantityToPick= 0;
        foreach (Prefabs prefabs in prefabsToConsider)
        {
            quantityToPick += prefabs.quantity;
        }
        int defaultPrefabQuantity = mapSize - quantityToPick;

        if (defaultPrefabQuantity < 0)
        {
            Debug.LogWarning("Distribution has too many tiles for the tile map size");
            return null;
        }
        
        // Get a random integer from 0 to PoolSize.
        int randomNumber = Random.Range(1, quantityToPick + defaultPrefabQuantity + 1);

        // Detect the item, which corresponds to current random number.
        int accumulatedProbability = 0;
        
        foreach (Prefabs prefabs in prefabsToConsider)
        {
            accumulatedProbability += prefabs.quantity;
            if (randomNumber <= accumulatedProbability)
            {
                prefabs.quantity -= 1;
                return prefabs.prefab;
            }
        }

        return defaultPrefab;
    }
}
