using System;
using System.Collections;
using Tiles;
using UnityEngine;

namespace Units.UnitTypes
{
    public class Gatherer : AbstractUnit
    {
        private TileReplacer replacer;
        private GameController gameController;
        protected override void Awake()
        {
            base.Awake();
            gameController = FindObjectOfType<GameController>();
            replacer = FindObjectOfType<TileReplacer>();

        }

        public override void AddToTile(GameObject tile)
        {
            Player.Player tileOwner = tile.GetComponent<TileController>().Owner;
            
            if(tileOwner != null && tileOwner.name.Equals(UnitController.Owner.name))
                tile.GetComponent<TileController>().tile.Gatherers.Add(this);
            else
                tile.GetComponent<TileController>().tile.EnemyAtackers.Add(this);
        }
     
        public IEnumerator Build(GameObject tileClicked, Vector3 planePosMouse, String prefab, int cost)
        {
            while ((transform.position - planePosMouse).magnitude > 0.3)
            {
                transform.position += (planePosMouse - transform.position).normalized * Time.fixedDeltaTime;
                yield return null;
            }
            replacer.Build(tileClicked,prefab);
            UnitController.Owner.resourceManager.removeMaterials(cost); 
            gameController.RefreshPlayersUI();
        }
    }
}