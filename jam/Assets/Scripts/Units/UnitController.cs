﻿using UnityEditor.Rendering;
using UnityEngine;

namespace Units
{
    public class UnitController : MonoBehaviour
    {
        public AbstractUnit unit;

        public Player.Player Owner;

        private UnitMovementController movement;

        private void Awake()
        {
            Owner = FindObjectOfType<GameController>().CurrentPlayer;
            movement = GetComponent<UnitMovementController>();
        }


        public void MoveTo(GameObject tileClicked, Vector3 planePosMouse)
        {
            movement.MoveToTile(tileClicked,planePosMouse);
        }
        
    }
}
