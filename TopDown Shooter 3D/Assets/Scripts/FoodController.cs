using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public String foodName;
    float x;
    public float dropRate;
    public int heal;
    private DropManager pooler;
    
    void Update () 
    {
        pooler = DropManager.Instance;
        x += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(0,x,0);
    }


    private void OnCollisionEnter(Collision other)
    {
        GameObject player = other.gameObject;
        if (player.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().HealBy(heal);
            // Debug.Log("FOOD CONSUMED");
            
            gameObject.SetActive(false);
            pooler.enqueueFood(gameObject);
            
            
        }
    }
}
