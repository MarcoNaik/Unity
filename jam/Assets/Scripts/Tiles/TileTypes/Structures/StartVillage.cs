using System;
using System.Collections;
using System.Collections.Generic;
using Tiles;
using UnityEngine;

public class StartVillage : MonoBehaviour
{
    private TileController _tileController;
    public int playerIndex;

    private void Awake()
    {
        _tileController = GetComponent<TileController>();
    }

    private void Start()
    {
        _tileController.Owner = FindObjectOfType<GameController>().players[playerIndex];
    }
}
