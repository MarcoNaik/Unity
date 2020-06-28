﻿using DefaultNamespace;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(TileController))]
public class TileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TileController tileController = (TileController) target;
        if (GUILayout.Button("EndTurn"))
        {
            tileController.tile.EndTurn();
        }
        if (GUILayout.Button("RefresIUnitsLists"))
        {
            tileController.tile.RefreshIUnitList();
            Debug.Log("def " + tileController.tile.Defenders.Count);
            Debug.Log("att" + tileController.tile.EnemyAtackers.Count);
            Debug.Log("gath" + tileController.tile.Gatherers.Count);
        }
        
        
            
    }
}