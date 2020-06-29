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
            int result = Versus(thisTile.Defenders, thisTile.EnemyAtackers, false);
            if(result == 1 ) OneWayAttackLoop(thisTile.EnemyAtackers, thisTile.Defenders);
        }

        
    }
}