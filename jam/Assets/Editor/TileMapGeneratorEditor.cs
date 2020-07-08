using MapGen;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(TileMapGenerator))]
    public class TileMapGeneratorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            TileMapGenerator mapGenerator = (TileMapGenerator) target;

            if (GUILayout.Button("Generate map."))
            {
                mapGenerator.GenerateMap();
            }
        
        
        
            
        }
    }
}