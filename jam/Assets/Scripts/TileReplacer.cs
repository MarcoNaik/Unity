﻿using System;
using System.Collections;
using System.Collections.Generic;
using Inputs.Commands;
using UnityEngine;

public class TileReplacer : MonoBehaviour
{
    private GameController gc;
    [System.Serializable]
    public class PrefabKeys
    {
        public GameObject prefab;
        public String Key;
    }

    public List<PrefabKeys> PrefabKeysList;

    private Dictionary<String, GameObject> tileDictionary;

    private void Awake()
    {
        tileDictionary = new Dictionary<string, GameObject>();
        gc = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        foreach (PrefabKeys prefabKey in PrefabKeysList)
        {
            tileDictionary.Add(prefabKey.Key, prefabKey.prefab);
        }
    }

    public void DestroyStructure(GameObject structureTile)
    {
        Build(structureTile, "default");
    }

    public void Build(GameObject tileToDestroy, String prefabKey)
    {
        Vector3 position = tileToDestroy.transform.position;
        gc.RemoveHex(tileToDestroy);
        Destroy(tileToDestroy);
        GameObject tempGO =Instantiate(tileDictionary[prefabKey],transform);
        gc.AddHex(tempGO);
        tempGO.transform.position = position;
    }
}
