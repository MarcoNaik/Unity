using System;
using System.Collections.Generic;
using UnityEngine;


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

        private ITileState tileState;

        protected AbstractTile(GameObject thisGameObject, GameObject owner, int tileTier)
        {
            Owner = owner; 
            this.tileTier = tileTier;
            gameObject = thisGameObject;
            Gatherers = new List<IUnit>();
            Defenders = new List<IUnit>();
            EnemyAtackers = new List<IUnit>();
            UnitsOnTop = new List<GameObject>();
            tileState = new BattleState(this); // OJO con ese default status
        }

        public void EndTurn()
        {
            tileState.ResolveTurn();
        }

        public void SetState(ITileState newState)
        {
            tileState = newState;
        }

        public bool isEmpty()
        {
            return Gatherers.Count == 0 && Defenders.Count == 0;
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
