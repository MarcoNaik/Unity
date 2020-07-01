using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace DefaultNamespace
{
    public class StateController : MonoBehaviour
    {
        private TileController tileController;

        private void Awake()
        {
            tileController = GetComponent<TileController>();
        }

        public void CheckState()
        {
            ITile tile = tileController.tile;
            tile.RefreshIUnitList();
            
            int stateID=0;
            IUnit def = CombatManager.UnitAlive(tile.Defenders);
            IUnit gath = CombatManager.UnitAlive(tile.Gatherers);
            IUnit att = CombatManager.UnitAlive(tile.EnemyAtackers);

            if (def != null) stateID += 1;
            if (att != null) stateID += 2;
            if (gath != null) stateID += 4;

            switch (stateID)
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
            IUnit attackEnemyUnitCase = CombatManager.UnitAlive(tileController.tile.EnemyAtackers);
            if (attackEnemyUnitCase != null)
            {
                tileController.Owner = attackEnemyUnitCase.UnitController.Owner;
                tileController.tile.RefreshIUnitList();
            }
            
            CheckState();
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