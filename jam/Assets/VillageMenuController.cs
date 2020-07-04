﻿using System;
using System.Collections;
using System.Collections.Generic;
using Tiles;
using Tiles.TileTypes.Structures;
using UnityEngine;

public class VillageMenuController : MonoBehaviour
{
    private Village currentVillage;

    private void OnEnable()
    {
        currentVillage = (Village)GetComponentInParent<UIManager>().currentObject.GetComponent<TileController>().tile;
    }

    public void SpawnVillagerButton()
    {
        currentVillage.SpawnVillager();
    }
}
