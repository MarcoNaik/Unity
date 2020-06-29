using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public interface ITile
    {
        List<IUnit> Gatherers { get; set; }
        List<IUnit> Defenders { get; set; }
        List<IUnit> EnemyAtackers { get; set; }
        
        List<GameObject> UnitsOnTop { get; set; }
        
        int TileTier { get; }
        GameObject Owner { get; set; }
        
        void DeliverThisResource(int resourcesToDeliver);
        GameObject gameObject { get; set; }

        IUnit AttackerAvailable(List<IUnit> list);
        IUnit UnitAlive(List<IUnit> list);


        void EndTurn();
        void RefreshIUnitList();
        
        ITileState tileState { get; set; }
    }
}