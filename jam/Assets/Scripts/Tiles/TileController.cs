using System;
using DefaultNamespace;
using UnityEngine;



public class TileController : MonoBehaviour
{ 
    public ITile tile;
    public int tier;
    public GameObject player;

    private void Awake()
    {
        if (gameObject.CompareTag($"WoodTile"))
        {
           
            tile = new MaterialsTile(gameObject, player, tier);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
    
        if (other.gameObject.layer == 9) tile.UnitsOnTop.Add(other.gameObject);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == 9) tile.UnitsOnTop.Remove(other.gameObject);
    }
}
