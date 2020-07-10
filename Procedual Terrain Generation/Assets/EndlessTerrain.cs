using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MapGenerator;

public class EndlessTerrain : MonoBehaviour
{
    public const float maxViewDist = 450;
    public Transform viewer;
    public Material material;

    private static MapGenerator mapGenerator;

    public static Vector2 viewerPosition;
    
    private int chunkSize;
    private int chunkVisibleInViewDistance;
    
    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
    private List<TerrainChunk> terrainChunksVisiblesLastUpdate = new List<TerrainChunk>();

    private void Start()
    {
        mapGenerator = FindObjectOfType<MapGenerator>();
        chunkSize = mapChunkSize - 1;
        chunkVisibleInViewDistance = Mathf.RoundToInt(maxViewDist / chunkSize);
    }

    private void Update()
    {
        viewerPosition = new Vector2(viewer.position.x,viewer.position.z);
        UpdateVisibleChunks();
    }

    void UpdateVisibleChunks()
    {
        foreach (TerrainChunk terrainChunk in terrainChunksVisiblesLastUpdate)
        {
            terrainChunk.SetVisible(false);
        }
        
        terrainChunksVisiblesLastUpdate.Clear();
        
        int currentChunkCoordX = Mathf.RoundToInt(viewerPosition.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(viewerPosition.y / chunkSize);
        for (int yOffset = -chunkVisibleInViewDistance; yOffset <= chunkVisibleInViewDistance; yOffset++)
        {
            for (int xOffset = -chunkVisibleInViewDistance; xOffset <= chunkVisibleInViewDistance; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX+xOffset , currentChunkCoordY + yOffset);
                if (terrainChunkDictionary.ContainsKey(viewedChunkCoord))
                {
                    terrainChunkDictionary[viewedChunkCoord].UpdateTerrainChunk();
                    if (terrainChunkDictionary[viewedChunkCoord].isVisible())
                    {
                        terrainChunksVisiblesLastUpdate.Add(terrainChunkDictionary[viewedChunkCoord]);
                    }
                }
                else
                {
                    terrainChunkDictionary.Add(viewedChunkCoord,new TerrainChunk(viewedChunkCoord, chunkSize,transform, material));
                }
            }
        }

    }
    public class TerrainChunk
    {
        private Vector2 position;
        private GameObject meshObject;
        private Bounds bounds;

        private MapData mapData;
        private MeshRenderer meshRenderer;
        private MeshFilter meshFilter;
        
        public TerrainChunk(Vector2 coord, int size, Transform parent, Material material)
        {
           
            position = coord * size;
            bounds = new Bounds(position,Vector2.one * size);
            
            Vector3 positionV3  =new Vector3(position.x, 0 ,position.y);
            
            meshObject = new GameObject("Terrain Chunk");

            meshFilter = meshObject.AddComponent<MeshFilter>();
            meshRenderer = meshObject.AddComponent<MeshRenderer>();
            meshRenderer.material = material;
            
            meshObject.transform.position = positionV3;
            meshObject.transform.parent = parent;
            SetVisible(false);
            
            mapGenerator.RequestMapData(OnMapDataReceived);
        }

        void OnMapDataReceived(MapData mapData)
        {
            mapGenerator.RequestMeshData(mapData, OnMeshDataReceived);
        }

        void OnMeshDataReceived(MeshData meshData)
        {
            meshFilter.mesh = meshData.CreateMesh();
        }

        public void UpdateTerrainChunk()
        {
            float viewerDistanceFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPosition));

            bool visible = viewerDistanceFromNearestEdge <= maxViewDist;
            
            SetVisible(visible);
        }

        public void SetVisible(bool visible)
        {
            meshObject.SetActive(visible);
        }

        public bool isVisible()
        {
            return meshObject.activeSelf;
        }
    }
}

