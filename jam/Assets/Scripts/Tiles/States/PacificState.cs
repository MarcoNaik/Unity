using Units;
using UnityEngine;

namespace Tiles.States
{
    
    public class PacificState : AbstractState
    {
        
        public override void ResolveTurn() => DeliverResources();

        public PacificState(ITile tile) : base(tile)
        {
        }
        

        public void DeliverResources()
        {
            int resourcesToDeliver = 0;
            int tileTier = thisTile.TileTier;
            if (tileTier == 0)
            {
                Debug.LogWarning("this tile has tier level 0!");
                return;
            }
            foreach (IUnit unit in thisTile.Gatherers)
            {
                var gatherer = unit;
                resourcesToDeliver += gatherer.getPowerLever();
                resourcesToDeliver /= tileTier;
            }
            thisTile.DeliverThisResource(resourcesToDeliver);
        }
    }
}