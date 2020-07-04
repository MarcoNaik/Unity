using Tiles.States;
using Units;

namespace Tiles
{
    public class ResourceDefaultStateController : AbstractStateController
    {
        protected override void SetState(int stateId)
        {
            switch (stateId)
            {
                case 0:
                    SetWildState();
                    return;
                case 1:
                    SetWildPacificState();
                    return;
                case 2:
                    SetWildPacificState();
                    return;
                case 3:
                    SetWildCombatState();
                    return;
                case 4:
                    SetPacificState();
                    return;
                case 5:
                    SetPacificState();
                    return;
                case 6:
                    SetBattleState();
                    return;
                case 7:
                    SetBattleState();
                    return;
            }
        }
        
        private void SetWildPacificState()
        {
            tileController.tileState = new WildPacificState(tileController.tile);
            IUnit attackEnemyUnitCase = Picker.UnitAlive(tileController.tile.EnemyAtackers);
            if (attackEnemyUnitCase != null)
            {
                tileController.Owner = attackEnemyUnitCase.UnitController.Owner;
                tileController.tile.RefreshIUnitList();
                CheckState();
            }
        }

        private void SetWildState()
        {
            tileController.tileState = new WildState(tileController.tile);
            tileController.Owner = null;
        }
        
        private void SetWildCombatState()
        {
            tileController.tileState =new WildCombatState(tileController.tile);
        }

        private void SetBattleState()
        {
            tileController.tileState = new BattleState(tileController.tile);
        }
        
        private void SetPacificState()
        {
            tileController.tileState =new PacificState(tileController.tile);
        }
    }
}