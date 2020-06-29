using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


namespace DefaultNamespace
{
    public abstract class AbstractTile: ITile
    {
        public GameObject gameObject { get; set; }
        public int tileTier;
        public int TileTier => tileTier;
        public GameObject Owner { get; set; }

        public List<GameObject> UnitsOnTop { get; set; }
        
        public List<IUnit> Gatherers { get; set; }

        public List<IUnit> Defenders { get; set; }

        public List<IUnit> EnemyAtackers { get; set; }

        public ITileState tileState { get; set; }

        protected AbstractTile(GameObject thisGameObject, GameObject owner, int tileTier)
        {
            Owner = owner; 
            this.tileTier = tileTier;
            gameObject = thisGameObject;
            Gatherers = new List<IUnit>();
            Defenders = new List<IUnit>();
            EnemyAtackers = new List<IUnit>();
            UnitsOnTop = new List<GameObject>();
            tileState = new WildState(this); // default status
        }
        
        
        
        //MAYBY THIS SHOULD BE AT ABSTRACT STATE BUT IDK, FOR SOME REASON I MOVE THEM HERE
        //pick an alive Unit and if is asked it has to have an attack available
        private IUnit CandidatePicker(List<IUnit> list, bool alsoAttacker )
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
        public IUnit AttackerAvailable(List<IUnit> list)
        {
            return CandidatePicker(list, true);
        }
        //pick an alive unit, return null if there are not unit alives
        public IUnit UnitAlive(List<IUnit> list)
        {
            return CandidatePicker(list, false);
        }

        
        
        public void EndTurn()
        {
            RefreshIUnitList();
            tileState.ResolveTurn();
            
        }
        
        public void RefreshIUnitList()
        {
            Gatherers = new List<IUnit>();
            Defenders = new List<IUnit>();
            EnemyAtackers = new List<IUnit>();
            
            foreach (GameObject unit in UnitsOnTop)
            { 
                IUnit iunit = unit.GetComponent<UnitController>().unit;
                if(iunit.Alive)
                    unit.GetComponent<UnitController>().unit.AddToTile(gameObject);
            }
   
        }
        public abstract void DeliverThisResource(int amount);
    }
}
