using System;
using System.Collections.Generic;
using System.Resources;
using Tiles.StateControllers.States;
using Tiles.Utilities;
using Units;
using UnityEngine;

namespace Tiles.TileTypes.Structures
{
    public abstract class AbstractStructure: AbstractTile
    {
        private ResourceInventory ownerResources;
        
        public Vector3 DefaultPositionToSpawn { get; set; }
        public GameObject DefaultTileToSpawn { get; set; }

        public int MaxHP;
        private int CurrentHP { get; set; }
        private Collider[] neighbourTiles;
        

        protected override void Awake()
        {
            base.Awake();
            
            tileController.tileState = new StructurePacificState(this);
            
            CurrentHP = MaxHP;
        }

        private void Start()
        {
            SetNeighbourTiles();
            tileController.Owner = FindObjectOfType<GameController>().thisTurnPlayer;
            ownerResources = tileController.Owner.resourceManager;
            SetSpawnPosTo(gameObject, transform.position + Vector3.up * 0.3f);
        }

        private void OnDestroy()
        {
            UnSetNeighbourTiles();
        }

        [System.Serializable]
        public class SpawnableUnit
        {
            public SpawnableUnit(GameObject prefab, int cost)
            {
                this.prefab = prefab;
                this.cost = cost;
            }

            public GameObject prefab;
            public int cost;
        }

        public List<SpawnableUnit> spawnableUnits;

        protected void Spawn(int unitIndex)
        {
            SpawnableUnit unit = spawnableUnits[unitIndex];
            if (ownerResources == null)
            {
                Debug.Log("owner resources = null");
            }
            
            Debug.Log( " has this food " + ownerResources.Food );

            if (ownerResources.Food >= unit.cost)
            {
                ownerResources.removeFood(unit.cost);
                GameObject tempGO = Instantiate(unit.prefab, transform);
                tempGO.transform.position = transform.position + Vector3.up * 1.5f;
                tempGO.GetComponent<UnitController>().MoveTo(DefaultTileToSpawn, DefaultPositionToSpawn);
            }
        }

        public void TakeDamage(int damage)
        {
            CurrentHP -= damage;
            if (CurrentHP <= 0) DestroyThisStructure();
        }

        private void DestroyThisStructure()
        {
            TileReplacer replacer = FindObjectOfType<TileReplacer>();
            replacer.DestroyStructure(gameObject);
        }

        public void SetSpawnPosTo(GameObject tileClicked, Vector3 planePosMouse)
        {
            DefaultPositionToSpawn = planePosMouse;
            DefaultTileToSpawn = tileClicked;
            
            Debug.Log("actual pos to spawn" + DefaultPositionToSpawn);
        }
        
        
        public override void AttackStructure()
        {
            foreach (IUnit enemy in EnemyAtackers)
            {
                TakeDamage(enemy.getPowerLever());
            }
        }

        private void SetNeighbourTiles()
        {
            
            neighbourTiles = Physics.OverlapSphere(transform.position, 1, 1<<8); // 8 hex map

            foreach (Collider tile in neighbourTiles)
            {
                tile.gameObject.AddComponent<StructureNeighbour>();
            }
        }
        
        private void UnSetNeighbourTiles()
        {
            foreach (Collider tile in neighbourTiles)
            {
                Destroy(tile.GetComponent<StructureNeighbour>());
            }
        }
    }
    
}