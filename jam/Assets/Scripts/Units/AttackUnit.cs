using UnityEngine;

namespace DefaultNamespace
{
    public class AttackUnit : AbstractUnit
    {
        public override void AddToTile(GameObject tile)
        {
            GameObject tileOwner = tile.GetComponent<TileController>().player;
            
            if(tileOwner != null && tileOwner.name.Equals(Owner.name)) 
                tile.GetComponent<TileController>().tile.Defenders.Add(this);
            else
                tile.GetComponent<TileController>().tile.EnemyAtackers.Add(this);
        }

        public AttackUnit(GameObject thisObject, GameObject owner, int powerLevel, int maxHP) : base(thisObject, owner, powerLevel, maxHP)
        {
        }
    }
}