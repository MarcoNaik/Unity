using UnityEngine;

namespace DefaultNamespace
{
    public class Gatherer : AbstractUnit, IGatherer
    {
        public override void AddToTile(GameObject tile)
        {
            if(tile.GetComponent<TileController>().player.name.Equals(Owner.name)) 
                tile.GetComponent<TileController>().tile.Gatherers.Add(this);
            else
                tile.GetComponent<TileController>().tile.EnemyAtackers.Add(this);

        }


        public Gatherer(GameObject thisObject, GameObject owner, int powerLevel, int maxHP) : base(thisObject, owner, powerLevel, maxHP)
        {
        }
    }
}