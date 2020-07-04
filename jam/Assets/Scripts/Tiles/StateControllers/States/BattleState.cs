using UnityEngine;

namespace Tiles.States
{
    
    public class BattleState: AbstractState
    {
        public override void ResolveTurn()
        {
            Combat();
        }
        
        

        //battle state
        private void Combat()
        {
            if (thisTile.Defenders.Count > 0) DefendersCombat();
            else
            {
                NoDefendersCombat();
            }
        }

        // def vs att
        private void DefendersCombat()
        {
            int result = CombatManager.Versus(thisTile.Defenders, thisTile.EnemyAtackers, false);
            Debug.Log(result);
            
            switch (result)
            {
                case 1:
                    CombatManager.DoubleOneWaySingleAttack(thisTile.Gatherers, thisTile.EnemyAtackers, thisTile.Defenders);
                    return;

                case 5: result = CombatManager.Versus(thisTile.Gatherers, thisTile.EnemyAtackers, true);
                    if (result == 1)
                        CombatManager.OneWayAttackLoop(thisTile.EnemyAtackers , thisTile.Gatherers);
                    
                    return;
                case 6:CombatManager.OneWayAttackLoop(thisTile.Gatherers, thisTile.EnemyAtackers);
                    return;

                case 7:
                    Debug.Log(result);
                    CombatManager.OneWayAttackLoop(thisTile.Gatherers, thisTile.EnemyAtackers);
                    return;
                default:
                    return;
            }

        }

        // gath vs att
        protected virtual void NoDefendersCombat()
        {
            int result = CombatManager.Versus(thisTile.Gatherers, thisTile.EnemyAtackers, false);
            if (result == 1)
            {
                CombatManager.OneWayAttackLoop(thisTile.EnemyAtackers, thisTile.Gatherers);
            }
        }


        public BattleState(AbstractTile tile) : base(tile)
        {
        }
    }
}