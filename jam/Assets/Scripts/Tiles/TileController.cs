using System;
using System.Collections;
using System.Collections.Generic;
using Tiles.States;
using UnityEngine;

namespace Tiles
{
    public class TileController : MonoBehaviour
    { 
        public AbstractTile tile;
        public Player Owner { get; set; }

        public ITileState tileState;

        private StateController stateController;

        private Queue<IEnumerator> Coroutines;

        private Task currentTask;

        private void Awake()
        {
            stateController = GetComponent<StateController>();
            Coroutines = new Queue<IEnumerator>();
            Owner = null;
            tileState= new WildState(tile);
        }

        private void FixedUpdate()
        {
            if (Coroutines.Count != 0)
            {
                if (currentTask == null)
                {
                    currentTask = new Task(Coroutines.Dequeue());
                }

                if (!currentTask.Running)
                {
                    currentTask = new Task(Coroutines.Dequeue());
                }
                
            }
        }


        public void EndTurn()
        {
            tile.RefreshIUnitList();
            stateController.CheckState();
            tileState.ResolveTurn();
           
        }


        private void OnCollisionEnter(Collision other)
        {
    
            if (other.gameObject.layer == 9) tile.UnitsOnTop.Add(other.gameObject);
        
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.layer == 9) tile.UnitsOnTop.Remove(other.gameObject);
        }

        public void addCoroutine(IEnumerator attackCoroutine)
        {
            Coroutines.Enqueue(attackCoroutine);
        }
    }
}
