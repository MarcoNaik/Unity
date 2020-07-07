using UnityEngine;

namespace Tiles.TileTypes.Structures
{
    public class Village : AbstractStructure
    {

        public GameObject menu;

        public void SpawnVillager()
        {
            Spawn(0);
        }
        

        
        public override void DeliverThisResource(int amount)
        {
            
        }

        
    }
}