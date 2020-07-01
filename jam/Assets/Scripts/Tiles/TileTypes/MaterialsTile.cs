using UnityEngine;

namespace DefaultNamespace
{
    public class MaterialsTile : AbstractTile
    {
        public override void DeliverThisResource(int amount)
        {
            GetComponent<TileController>().Owner.resourceManager.addMaterials(amount);
        }

    }
}