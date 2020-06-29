using UnityEngine.Rendering;

namespace DefaultNamespace
{
    public class StateController
    {
        public static void CheckState(TileController aTileController)
        {
            ITile tile = aTileController.tile;
            TileController tileController = aTileController;
            tile.RefreshIUnitList();
            int stateID=0;
            IUnit def = tile.UnitAlive(tile.Defenders);
            IUnit gath = tile.UnitAlive(tile.Gatherers);
            IUnit att = tile.UnitAlive(tile.EnemyAtackers);

            if (def != null) stateID += 1;
            if (att != null) stateID += 2;
            if (gath != null) stateID += 4;

            switch (stateID)
            {
                case 0:
                    SetWildState(tileController);
                    return;
                case 1:
                    SetWildPacificState(tileController);
                    return;
                case 2:
                    SetWildPacificState(tileController);
                    return;
                case 3:
                    SetWildCombatState(tileController);
                    return;
                case 4:
                    SetPacificState(tileController);
                    return;
                case 5:
                    SetPacificState(tileController);
                    return;
                case 6:
                    SetBattleState(tileController);
                    return;
                case 7:
                    SetBattleState(tileController);
                    return;
            }

        }

        private static void SetWildPacificState(TileController atile)
        {
            atile.tile.tileState = new WildPacificState(atile.tile);
            IUnit attackEnemyUnitCase = atile.tile.UnitAlive(atile.tile.EnemyAtackers);
            if (attackEnemyUnitCase != null)
            {
                atile.player = atile.tile.UnitAlive(atile.tile.EnemyAtackers).Owner;
                atile.tile.RefreshIUnitList();
            }
            
            CheckState(atile);
        }

        private static void SetWildState(TileController tile)
        {
            tile.tile.tileState = new WildState(tile.tile);
            tile.player = null;
        }
        
        private static void SetWildCombatState(TileController tile)
        {
            tile.tile.tileState =new WildCombatState(tile.tile);
        }

        private static void SetBattleState(TileController tile)
        {
            tile.tile.tileState = new BattleState(tile.tile);
        }
        
        private static void SetPacificState(TileController tile)
        {
            tile.tile.tileState =new PacificState(tile.tile);
        }
      
    }
}