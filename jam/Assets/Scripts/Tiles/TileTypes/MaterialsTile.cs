namespace Tiles.TileTypes
{
    public class MaterialsTile : AbstractTile
    {
        public override void DeliverThisResource(int amount)
        {
            GetComponent<TileController>().Owner.resourceManager.addMaterials(amount);
        }

    }
}