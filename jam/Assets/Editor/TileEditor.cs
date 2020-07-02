using Tiles;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(TileController))]
    public class TileEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            TileController tileController = (TileController) target;
            if (GUILayout.Button("EndTurn"))
            {
                tileController.EndTurn();
            }
            if (GUILayout.Button("Refresh IUnits Lists"))
            {
                tileController.tile.RefreshIUnitList();
                Debug.Log("def " + tileController.tile.Defenders.Count);
                Debug.Log("att" + tileController.tile.EnemyAtackers.Count);
                Debug.Log("gath" + tileController.tile.Gatherers.Count);
            }
            
        
        
            
        }
    }
}
