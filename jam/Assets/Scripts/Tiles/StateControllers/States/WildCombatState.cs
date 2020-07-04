namespace Tiles.States
{
    class WildCombatState : AbstractState
    {
       

        public override void ResolveTurn()
        {
            Combat();
        }

        private void Combat()
        {
            int result = CombatManager.Versus(thisTile.Defenders, thisTile.EnemyAtackers, false);
            if(result == 1 ) CombatManager.OneWayAttackLoop(thisTile.EnemyAtackers, thisTile.Defenders);
        }


        public WildCombatState(AbstractTile tile) : base(tile)
        {
        }
    }
}