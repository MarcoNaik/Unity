using System;
using System.Collections;
using System.Collections.Generic;
using Tiles.StateControllers;
using Tiles.StateControllers.States;
using Tiles.Utilities;
using UnityEngine;

namespace Tiles
{
    public class TileController : MonoBehaviour
    { 
        public AbstractTile tile;

        public Player Owner;

        public ITileState tileState;

        public AbstractStateController stateController;

        private Queue<IEnumerator> Coroutines;

        private Task currentTask;
        private Task setUp;
        Transform bordersTransform;

        private void Awake()
        {
            Coroutines = new Queue<IEnumerator>();
            Owner = null;
            tileState= new WildState(tile);
            bordersTransform = GetComponentInChildren<Borders>().transform;
            //tile.enabled = true;
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


        private IEnumerator FinishEndTurnCoroutine()
        {
            while (bordersTransform.position.y > 0)
            {
                bordersTransform.position+= Vector3.down * Time.deltaTime * 0.1f;
                yield return null;
            }
        }
        private IEnumerator EndTurnCoroutine()
        {

            while (bordersTransform.position.y < 0.3)
            {
                bordersTransform.position+= Vector3.up * Time.deltaTime* 0.1f;
                yield return null;
            }

            tile.RefreshIUnitList();
            tile.ClearAttackers();
            stateController.CheckState();
            tileState.ResolveTurn();
            addCoroutine(FinishEndTurnCoroutine());
            
        }
        public void EndTurn()
        {
            addCoroutine(EndTurnCoroutine());
            
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
