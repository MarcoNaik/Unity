using Tiles;
using UnityEngine;

namespace Units.UnitTypes
{
    public class AttackUnit : AbstractUnit
    {
        public override void AddToTile(GameObject tile)
        {
            Player tileOwner = tile.GetComponent<TileController>().Owner;
            
            if(tileOwner != null && tileOwner.name.Equals(UnitController.Owner.name)) 
                tile.GetComponent<TileController>().tile.Defenders.Add(this);
            else
                tile.GetComponent<TileController>().tile.EnemyAtackers.Add(this);
        }
        
    }
}