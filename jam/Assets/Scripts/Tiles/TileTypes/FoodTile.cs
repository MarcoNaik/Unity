using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace DefaultNamespace
{
    public class FoodTile : AbstractTile
    {
        public override void DeliverThisResource(int amount)
        {
            Owner.GetComponent<Player>().resourceManager.addFood(amount);
        }


        public FoodTile(GameObject thisGameObject, GameObject owner, int tileTier) : base(thisGameObject, owner, tileTier)
        {
        }
    }
}