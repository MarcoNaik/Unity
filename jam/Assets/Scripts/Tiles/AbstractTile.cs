using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.WSA;
using Random = UnityEngine.Random;


namespace DefaultNamespace
{
    public abstract class AbstractTile: MonoBehaviour, ITile
    {
        public int tileTier;
        public int TileTier => tileTier;

        public List<GameObject> UnitsOnTop { get; set; }
        
        public List<IUnit> Gatherers { get; set; }

        public List<IUnit> Defenders { get; set; }

        public List<IUnit> EnemyAtackers { get; set; }


        //private TileController tileController;

        private void Awake()
        {
            UnitsOnTop = new List<GameObject>();
            Gatherers = new List<IUnit>();
            Defenders = new List<IUnit>();
            EnemyAtackers = new List<IUnit>();
            //tileController = GetComponent<TileController>();
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
