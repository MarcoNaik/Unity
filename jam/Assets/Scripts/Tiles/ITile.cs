using System.Collections.Generic;
using Tiles.States;
using Units;

namespace Tiles
{
    public interface ITile
    {
        List<IUnit> Gatherers { get; }
        List<IUnit> Defenders { get;}
        List<IUnit> EnemyAtackers { get;}

        int TileTier { get; }
        CombatManager CombatManager { get; set; }

        void DeliverThisResource(int resourcesToDeliver);

        void RefreshIUnitList();
    }
}