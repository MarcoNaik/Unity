using System;
using UnityEngine;

namespace Tiles.Utilities
{
    public class StructureNeighbour:MonoBehaviour
    {
        public Player.Player owner;
        private void Awake()
        {
            owner = FindObjectOfType<GameController>().CurrentPlayer;
        }
    }
}