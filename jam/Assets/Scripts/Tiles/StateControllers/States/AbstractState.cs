namespace Tiles.States
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