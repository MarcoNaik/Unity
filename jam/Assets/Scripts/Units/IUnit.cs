using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IUnit
    {
        bool HasAttacked();
        void Attack(AbstractUnit receiveAttack);
        void TakeDamage(int powerLevel);
        int getPowerLever();
        void AddToTile(GameObject tile);
        UnitController UnitController { get; set; }
        bool Alive { get; set; }
    }
}