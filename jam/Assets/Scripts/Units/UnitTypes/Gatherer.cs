using Tiles;
using UnityEngine;

namespace Units.UnitTypes
{
    public class Gatherer : AbstractUnit
    {
        private TileReplacer replacer;

        protected override void Awake()
        {
            base.Awake();
            TileReplacer replacer = FindObjectOfType<TileReplacer>();
        }
        public override void AddToTile(GameObject tile)
        {
            Player tileOwner = tile.GetComponent<TileController>().Owner;
            
            if(tileOwner != null && tileOwner.name.Equals(UnitController.Owner.name))
                tile.GetComponent<TileController>().tile.Gatherers.Add(this);
            else
                tile.GetComponent<TileController>().tile.EnemyAtackers.Add(this);
        }
        
        //public void Build
       
    }
}