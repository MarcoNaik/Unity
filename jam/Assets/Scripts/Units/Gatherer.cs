using Tiles;
using UnityEngine;

namespace Units
{
    public class Gatherer : AbstractUnit, IGatherer
    {
        public override void AddToTile(GameObject tile)
        {
            Player tileOwner = tile.GetComponent<TileController>().Owner;
            
            if(tileOwner != null && tileOwner.name.Equals(UnitController.Owner.name))
                tile.GetComponent<TileController>().tile.Gatherers.Add(this);
            else
                tile.GetComponent<TileController>().tile.EnemyAtackers.Add(this);
        }
       
    }
}