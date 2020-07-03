using System;
using System.Collections;
using System.Collections.Generic;
using MapGen;
using Tiles;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player[] players;
    

    public Player thisTurnPlayer;
    private TileMapGenerator mapGenerator;
    
    
    private List<GameObject> hexMap;
    private int turn;

    private void Awake()
    {
        hexMap = new List<GameObject>();
        mapGenerator = GetComponentInChildren<TileMapGenerator>();
        thisTurnPlayer = players[1];
        turn = 1;
    }

    private void Start()
    {
        mapGenerator.GenerateMap();
    }

    public void EndTurn()
    {
        HexGlobalEndTurn();
        turn++;
        thisTurnPlayer = players[turn % 2];
    }

    private void HexGlobalEndTurn()
    {
        foreach (GameObject tile in hexMap)
        {
            tile.GetComponent<TileController>().EndTurn();
        }
    }
    public void AddHex(GameObject hex)
    {
        hexMap.Add(hex);
    }


}
