namespace Tiles.States
{
    public abstract class AbstractState : ITileState
    {
        public AbstractState(ITile tile)
        {
            thisTile = tile;
            CombatManager = thisTile.CombatManager;
        }
        protected ITile thisTile;
        
        protected CombatManager CombatManager;
       
        public abstract void ResolveTurn();
    }
    
    
    
}