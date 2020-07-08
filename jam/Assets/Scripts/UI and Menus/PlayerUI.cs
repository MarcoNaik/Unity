using System;
using TMPro;
using UnityEngine;

namespace UI_and_Menus
{
    public class PlayerUI : MonoBehaviour
    {
        public Player.Player player;
        private String playerName;
        private String food;
        private String materials;

        public GameObject playerNameTextObject;
        public GameObject foodTextObject;
        public GameObject materialsTextObject;

        private TextMeshProUGUI foodTextMesh;
        private TextMeshProUGUI materialsTextMesh;

        public int playerIndex;

        private void Awake()
        {
            foodTextMesh = foodTextObject.GetComponent<TextMeshProUGUI>();
            materialsTextMesh = materialsTextObject.GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            player = FindObjectOfType<GameController>().players[playerIndex];
            playerName = player.name;
            playerNameTextObject.GetComponent<TextMeshProUGUI>().text = playerName;
        
            RefreshTexts();
        }

        public void RefreshTexts()
        {
            food = player.resourceManager.Food.ToString();
            materials = player.resourceManager.Materials.ToString();
        
            foodTextMesh.text = food;
            materialsTextMesh.text = materials;
        }
    }
}
