
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    
    public class BattleState: AbstractState
    {
        
        public override void ResolveTurn()
        {
            Combat();
        }
        

        
        private void Tie()
        {
            Debug.Log("hey we tied");
        }

        private void AttackersWin()
        {
            
            thisTile.Owner = thisTile.UnitAlive(thisTile.EnemyAtackers).Owner;
            Debug.Log("hey we lost :-(");
        }

        private void DefendersWin()
        {
            Debug.Log("hey we won fuck yeah! XD");
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
            int result = Versus(thisTile.Defenders, thisTile.EnemyAtackers, false);
            switch (result)
            {
                case 1:
                    result = DoubleOneWaySingleAttack(thisTile.Gatherers, thisTile.EnemyAtackers, thisTile.Defenders);
                    if (result == 1) Tie();
                    if (result == 2) DefendersWin();
                    if (result == 3) AttackersWin();
                    return;
                    
                case 2: DefendersWin();
                    return;
                case 3: DefendersWin();
                    return;

                case 5: result = Versus(thisTile.Gatherers, thisTile.EnemyAtackers, true);
                    if (result == 1)
                    {
                        result = OneWayAttackLoop(thisTile.EnemyAtackers , thisTile.Gatherers);
                        if (result == 1) Tie();
                        if (result == 2 || result == 3) AttackersWin();
                        return;
                    }
                    break;
                case 6: result = OneWayAttackLoop(thisTile.Gatherers, thisTile.EnemyAtackers);
                    break;

                case 7: result = OneWayAttackLoop(thisTile.Gatherers, thisTile.EnemyAtackers);
                    break;
            }

            switch (result)
            {
                case 1: Tie();
                    return;
                case 2: DefendersWin();
                    return;
                case 3: DefendersWin();
                    return;
                case 5: AttackersWin();
                    return;
                case 6: AttackersWin();
                    return;
                case 7: Tie();
                    return;
            }

        }

        // gath vs att
        private void NoDefendersCombat()
        {
            int result = Versus(thisTile.Gatherers, thisTile.EnemyAtackers, false);
            switch (result)
            {
                case 1:
                    result = OneWayAttackLoop(thisTile.EnemyAtackers , thisTile.Gatherers);
                    if (result == 1) Tie();
                    if (result == 2 || result == 3) AttackersWin();
                    break;
                case 2:
                    DefendersWin();
                    break;
                case 3:
                    DefendersWin();
                    break;
                case 5:
                    AttackersWin();
                    break;
                case 6:
                    AttackersWin();
                    break;
                case 7:
                    Tie();
                    break;
                
            }
        }


        public BattleState(ITile tile) : base(tile)
        {
        }
    }
}