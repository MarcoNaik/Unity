using Tiles.Utilities;

namespace Tiles.StateControllers.States
{
    public abstract class AbstractState : ITileState
    {
        public AbstractState(AbstractTile tile)
        {
            thisTile = tile;
            CombatManager = thisTile.CombatManager;
        }
        protected AbstractTile thisTile;
        
        protected CombatManager CombatManager;
       
        public abstract void ResolveTurn();
    }
    
    
    
}