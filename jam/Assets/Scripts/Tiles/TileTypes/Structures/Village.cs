﻿using UnityEngine;

namespace Tiles.TileTypes.Structures
{
    public class Village : AbstractStructure
    {

        public GameObject menu;
        /*
         * spawn units
         * HP
         * upgrade -> town
         * owner set when structured is built
         */

        public void SpawnVillager()
        {
            Spawn(0);
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        public override void DeliverThisResource(int amount)
        {
            
        }

        
    }
}