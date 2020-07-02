using System.Collections;
using System.Collections.Generic;
using Tiles;
using Units;
using UnityEngine;

public class RangeUnit : AttackUnit
{
    public int range;
    

    public void Attack()
    {
        Attack(GetTarget());
    }

    private IUnit GetTarget()
    {
        List<IUnit> possiblesTargets = new List<IUnit>();

        Collider[] hexOnRange = Physics.OverlapSphere(transform.position, range, 8); // 8 hex map

        foreach (Collider hex in hexOnRange)
        {
            TileController tileController = hex.GetComponent<TileController>();
            if (tileController.Owner == UnitController.Owner)
            {
                AddEnemyIn(tileController.tile.EnemyAtackers, possiblesTargets);
            }
            else
            {
                AddEnemyIn(tileController.tile.Gatherers, possiblesTargets);
                AddEnemyIn(tileController.tile.Defenders, possiblesTargets);
            }
        }

        return possiblesTargets[Random.Range(0, possiblesTargets.Count)];
    }

    private void AddEnemyIn(List<IUnit> list, List<IUnit> targets)
    {
        if (list.Count != 0)
        {
            foreach (IUnit enemy in list)
            {
                targets.Add(enemy);
            }
        }
    }
}
