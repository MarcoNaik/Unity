namespace Tiles.TileTypes
{
    public class FoodTile : AbstractTile
    {
        public override void DeliverThisResource(int amount)
        {
            GetComponent<TileController>().Owner.resourceManager.addFood(amount);
        }

        
    }
}