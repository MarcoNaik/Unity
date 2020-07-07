using System.Collections;
using System.Collections.Generic;
using Tiles.TileTypes.Structures;
using UnityEngine;

public class Town : AbstractStructure
{
    public void SpawnVillager()
    {
        Spawn(0);
    }

    public override void DeliverThisResource(int amount)
    {
        throw new System.NotImplementedException();
    }
}
