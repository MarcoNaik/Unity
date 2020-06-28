namespace DefaultNamespace
{
    
    public class PacificState : AbstractState ,ITileState
    {
        
        public void ResolveTurn() => DeliverResources();

        public PacificState(ITile tile) : base(tile)
        {
        }
        

        public void DeliverResources()
        {
            int resourcesToDeliver = 0;
            foreach (IUnit unit in thisTile.Gatherers)
            {
                var gatherer = unit;
                resourcesToDeliver += gatherer.getPowerLever();
                resourcesToDeliver /= thisTile.TileTier;
            }
            thisTile.DeliverThisResource(resourcesToDeliver);
        }
    }
}