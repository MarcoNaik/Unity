using System.Collections;
using System.Collections.Generic;
using Tiles.TileTypes.Structures;
using UnityEngine;

public class Factory : AbstractStructure
{
    public void SpawnAttackMinion()
    {
        Spawn(0);
    }
        

        
    public override void DeliverThisResource(int amount)
    {
            
    }

}
