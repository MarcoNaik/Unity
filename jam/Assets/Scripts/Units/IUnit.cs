using System.Collections;
using UnityEngine;

namespace Units
{
    public interface IUnit
    {
        bool HasAttacked();
        IEnumerator AttackCoroutine(AbstractUnit attackReceiver, bool bUnitAlive);
        void TakeDamage(int powerLevel);
        int getPowerLever();
        void AddToTile(GameObject tile);
        UnitController UnitController { get; set; }
        bool Alive { get; set; }
        void CleanAttack();
        void Attack(IUnit attackReceiver);
    }
}