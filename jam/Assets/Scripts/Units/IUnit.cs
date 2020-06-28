using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IUnit
    {
        GameObject Owner { get; set; }
        GameObject GameObject { get; set; }
        bool HasAttacked();
        void Attack(IUnit receiveAttack);
        void TakeDamage(int powerLevel);
        int getPowerLever();
        void AddToTile(GameObject tile);
        bool Alive { get; set; }
    }
}