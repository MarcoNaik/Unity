namespace Tiles.TileTypes
{
    public class FoodTile : AbstractTile
    {
        public override void DeliverThisResource(int amount)
        {
            tileController.Owner.resourceManager.addFood(amount);
        }

        
    }
}