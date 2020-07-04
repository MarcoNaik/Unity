using System;
using System.Collections.Generic;
using System.Resources;
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

        private void Awake()
        {
            SetSpawnPosTo(gameObject, transform.position + Vector3.up * 0.3f);
            ownerResources = tileController.Owner.resourceManager;
            CurrentHP = MaxHP;
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
            
            if (ownerResources.Food >= unit.cost)
            {
                ownerResources.removeFood(unit.cost);
                GameObject tempGO = Instantiate(unit.prefab, transform);
                tempGO.transform.position = transform.position + Vector3.up * 3f;
                tempGO.GetComponent<UnitMovementController>().MoveToTile(DefaultTileToSpawn, DefaultPositionToSpawn);
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
        }
        
        
        public override void AttackStructure()
        {
            foreach (IUnit enemy in EnemyAtackers)
            {
                TakeDamage(enemy.getPowerLever());
            }
        }
    }
    
}