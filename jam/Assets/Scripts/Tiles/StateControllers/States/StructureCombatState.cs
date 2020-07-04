using Tiles.States;

namespace Tiles
{
    class StructureCombatState : BattleState
    {
        

        protected override void NoDefendersCombat()
        {
            if (thisTile.Gatherers.Count <= 0)
            {
                thisTile.AttackStructure();
            }
            else
            {
                int result = CombatManager.Versus(thisTile.Gatherers, thisTile.EnemyAtackers, false);
                if (result == 1)
                {
                    CombatManager.OneWayAttackLoop(thisTile.EnemyAtackers, thisTile.Gatherers);
                }
                else
                {
                    //thisTile.AttackStructure();
                }
            }
        }

        public StructureCombatState(AbstractTile tile) : base(tile)
        {
        }
    }
}