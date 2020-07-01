using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace DefaultNamespace
{
    public class FoodTile : AbstractTile
    {
        public override void DeliverThisResource(int amount)
        {
            GetComponent<TileController>().Owner.resourceManager.addFood(amount);
        }

        
    }
}