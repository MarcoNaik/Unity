using System;
using System.Collections;
using System.Collections.Generic;
using Inputs.Commands;
using UnityEngine;

public class TileReplacer : MonoBehaviour
{
    public GameObject village;
    public GameObject defaultTile;


    public void BuildVillage(GameObject tile)
    {
       Build(tile,village);
    }

    public void DestroyStructure(GameObject structureTile)
    {
        Build(structureTile, defaultTile);
    }
    
    private void Build(GameObject tileToDestroy, GameObject prefab)
    {
        Vector3 position = tileToDestroy.transform.position;
        Destroy(tileToDestroy);
        GameObject tempGO =Instantiate(prefab,transform);
        tempGO.transform.position = position;
    }
}
