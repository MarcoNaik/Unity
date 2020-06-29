using UnityEngine;

namespace DefaultNamespace
{
    public class Gatherer : AbstractUnit, IGatherer
    {
        public override void AddToTile(GameObject tile)
        {
            GameObject tileOwner = tile.GetComponent<TileController>().player;
            
            if(tileOwner != null && tileOwner.name.Equals(Owner.name)) 
                tile.GetComponent<TileController>().tile.Gatherers.Add(this);
            else
                tile.GetComponent<TileController>().tile.EnemyAtackers.Add(this);
        }
        
        public Gatherer(GameObject thisObject, GameObject owner, int powerLevel, int maxHP) : base(thisObject, owner, powerLevel, maxHP)
        {
        }
    }
}