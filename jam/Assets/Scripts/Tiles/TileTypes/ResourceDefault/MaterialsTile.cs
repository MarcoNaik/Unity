namespace Tiles.TileTypes.ResourceDefault
{
    public class MaterialsTile : AbstractTile
    {
        public override void DeliverThisResource(int amount)
        {
            tileController.Owner.resourceManager.addMaterials(amount);
        }

        
    }
}