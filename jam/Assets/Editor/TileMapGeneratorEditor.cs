using System.Security.Cryptography.X509Certificates;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileMapGenerator))]
public class TileMapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TileMapGenerator mapGenerator = (TileMapGenerator) target;
        
        if (GUILayout.Button("Generate map"))
        {
            mapGenerator.GenerateMap();
        }
        
        
        
            
    }
}