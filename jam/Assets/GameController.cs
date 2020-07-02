using System;
using System.Collections;
using System.Collections.Generic;
using MapGen;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player[] players;
    

    private Player thisTurnPlayer;
    private TileMapGenerator mapGenerator;
    
    private int turn;

    private void Awake()
    {
        mapGenerator = GetComponentInChildren<TileMapGenerator>();
        thisTurnPlayer = players[0];
        turn = 1;
    }

    private void Start()
    {
        mapGenerator.GenerateMap();
    }

    private void EndTurn()
    {
        //notify a todas las tiles que hagan su EndTurn
        turn++;
        thisTurnPlayer = players[turn % 2 + 1];
    }
    
}
