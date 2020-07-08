using System;
using Tiles;
using TMPro;
using UnityEngine;

namespace UI_and_Menus
{
    public class TilePublicMenu : Refreshable
    {
        public TileController currentTileController;
        private String type;
        private String ownerName;
        private int tier;

        public GameObject typeTextObject;
        public GameObject ownerNameTextObject;
        public GameObject tierTextObject;
        private void OnEnable()
        {
            currentTileController = GetComponentInParent<UIManager>().currentObject.GetComponent<TileController>();
            if (currentTileController.Owner == null)
            {
                ownerName = "Wild";
            }
            else
            {
                ownerName = currentTileController.Owner.name;
            }
        
            type = currentTileController.tile.tag;
            tier = currentTileController.tile.tileTier;
            RefreshTexts();
        }

        public override void RefreshTexts()
        {
            typeTextObject.GetComponent<TextMeshProUGUI>().text = type;
            ownerNameTextObject.GetComponent<TextMeshProUGUI>().text = "Current owner: " + ownerName;
            tierTextObject.GetComponent<TextMeshProUGUI>().text = tier.ToString();
        }
    
    }
}
