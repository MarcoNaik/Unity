using System;
using System.Collections.Generic;
using Tiles.States;
using Units;
using UnityEngine;


namespace Tiles
{
    public abstract class AbstractTile: MonoBehaviour, ITile
    {
        public int tileTier;
        public int TileTier => tileTier;
        public CombatManager CombatManager { get; set; }

        public List<GameObject> UnitsOnTop { get; set; }
        
        public List<IUnit> Gatherers { get; set; }

        public List<IUnit> Defenders { get; set; }

        public List<IUnit> EnemyAtackers { get; set; }


        protected TileController tileController;

        private void Awake()
        {
            CombatManager = GetComponent<CombatManager>();
            UnitsOnTop = new List<GameObject>();
            Gatherers = new List<IUnit>();
            Defenders = new List<IUnit>();
            EnemyAtackers = new List<IUnit>();
            tileController = GetComponent<TileController>();
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

        public void ClearAttackers()
        {
            ClearIUnitAttacked(Gatherers);
            ClearIUnitAttacked(EnemyAtackers);
            ClearIUnitAttacked(Defenders);
        }

        private void ClearIUnitAttacked(List<IUnit> thisList)
        {
            foreach (IUnit unit in thisList)
            {
                unit.CleanAttack();
            }
        }

        public virtual void AttackStructure()
        {
            
        }
    }
}
