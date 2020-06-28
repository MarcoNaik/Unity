using UnityEngine.WSA;

namespace DefaultNamespace
{
    public abstract class AbstractState
    {
        public AbstractState(ITile tile)
        {
            this.thisTile = tile;
        }
        protected readonly ITile thisTile;
        
        
    }
}