using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public interface ITile
    {
        List<IUnit> Gatherers { get; }
        List<IUnit> Defenders { get;}
        List<IUnit> EnemyAtackers { get;}

        int TileTier { get; }
        
        void DeliverThisResource(int resourcesToDeliver);

        void RefreshIUnitList();
    }
}