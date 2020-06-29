using UnityEngine;

namespace DefaultNamespace
{
    public class MaterialsTile : AbstractTile
    {
        public override void DeliverThisResource(int amount)
        {
            Owner.GetComponent<Player>().resourceManager.addMaterials(amount);
        }


        public MaterialsTile(GameObject thisGameObject, GameObject owner, int tileTier) : base(thisGameObject, owner, tileTier)
        {
        }
    }
}