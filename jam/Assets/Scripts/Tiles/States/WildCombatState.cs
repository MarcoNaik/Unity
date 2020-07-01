using System.Collections.Generic;
using System.ComponentModel;

namespace DefaultNamespace
{
    class WildCombatState : AbstractState
    {
        public WildCombatState(ITile tile) : base(tile)
        {
        }

        public override void ResolveTurn()
        {
            Combat();
        }

        private void Combat()
        {
            int result = CombatManager.Versus(thisTile.Defenders, thisTile.EnemyAtackers, false);
            if(result == 1 ) CombatManager.OneWayAttackLoop(thisTile.EnemyAtackers, thisTile.Defenders);
        }

        
    }
}