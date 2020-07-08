namespace Tiles.TileTypes.Structures
{
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
}
