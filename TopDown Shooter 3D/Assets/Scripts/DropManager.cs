using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject prefab;
        public int size;
    }
    
    public static DropManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    
    private Dictionary<String, Queue<GameObject>> foodDictionary;
    public List<Pool> foods;
    private void Start()
    {
        foodDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool foodPool in foods)
        {
            Queue<GameObject> foodQueue = new Queue<GameObject>();
            
            for (int i = 0; i < foodPool.size; i++)
            {
                GameObject food = Instantiate(foodPool.prefab);
                food.SetActive(false);
                foodQueue.Enqueue(food);
            }
            foodDictionary.Add(foodPool.name, foodQueue);
            Debug.Log("key : " + foodPool.name + " Count : " + foodQueue.Count);
        }
    }

    public void DropFood(String foodname, GameObject dropedBy)
    {
        
        if (foodDictionary[foodname].Count == 0)
        {
            Debug.LogWarning("theres no Food on the " + foodname + " queue");
            return;
        }
        
        GameObject food = foodDictionary[foodname].Dequeue();

        if (food.GetComponent<FoodController>().dropRate > Random.Range(0, 100f))
        {
            food.SetActive(true);
            Debug.Log(food.name + "SPAWNED");
            food.transform.position = dropedBy.transform.position;
        }
        else
        {
            //Debug.Log("droprate fallido de " + food.name );   
        }
    }

    public void DropRandomFood(GameObject dropedBy)
    {
        for (int i = 0; i < foods.Count; i++)
        {
            DropFood(foods[i].name, dropedBy);
        }
    }

    public void enqueueFood(GameObject food)
    {
        foodDictionary[food.GetComponent<FoodController>().foodName].Enqueue(food);
        Debug.LogWarning("food queued with key " + food.GetComponent<FoodController>().foodName  +" Count :" + foodDictionary[food.GetComponent<FoodController>().foodName].Count);
    }
}
