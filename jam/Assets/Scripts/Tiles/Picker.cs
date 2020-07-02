using System.Collections.Generic;
using System.Linq;
using Units;
using UnityEngine;

namespace Tiles
{
    public static class Picker
    {
        //pick an alive Unit and if is asked it has to have an attack available
        private static IUnit CandidatePicker(List<IUnit> list, bool alsoAttacker )
        {
            List<IUnit> candidateList = new List<IUnit>();
            foreach (var unit in list.Where(unit => unit.Alive))
            {
                if (alsoAttacker)
                {
                    if (!unit.HasAttacked())
                    {
                        candidateList.Add(unit);
                    }
                }
                else
                {
                    candidateList.Add(unit);
                }
            }
            int range = candidateList.Count;
            if (range == 0) return null;
            return candidateList[Random.Range(0, range)];
        }
        
        //pick an alive unit who can also attack, return null if there are no attack availables
        public static IUnit AttackerAvailable(List<IUnit> list)
        {
            return CandidatePicker(list, true);
        }
        //pick an alive unit, return null if there are not unit alives
        public static IUnit UnitAlive(List<IUnit> list)
        {
            return CandidatePicker(list, false);
        }

    }
}