using System;
using Tiles;
using Tiles.TileTypes.Structures;
using UnityEngine;

namespace UI_and_Menus
{
    public class VillageMenuController : MonoBehaviour
    {
        private Village currentVillage;
        private GameController gameController;

        private void Awake()
        {
            gameController = FindObjectOfType<GameController>();
        }

        private void OnEnable()
        {
            currentVillage = (Village)GetComponentInParent<UIManager>().currentObject.GetComponent<TileController>().tile;
        }

        public void SpawnVillagerButton()
        {
            currentVillage.SpawnVillager();
            gameController.RefreshPlayersUI();
            
        }
    }
}
