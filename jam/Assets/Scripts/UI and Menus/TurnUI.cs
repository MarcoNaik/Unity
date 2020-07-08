using System;
using TMPro;
using UnityEngine;

namespace UI_and_Menus
{
    public class TurnUI : MonoBehaviour
    {
        private GameController gameController;
        private String currentPlayerName;
    
        public GameObject playerNameTextObject;
    
        private void Start()
        {
            gameController = FindObjectOfType<GameController>();
        
            RefreshTexts();
        }
    
        public void RefreshTexts()
        {
            currentPlayerName = gameController.CurrentPlayer.name;
        
            playerNameTextObject.GetComponent<TextMeshProUGUI>().text = currentPlayerName;
        }
    }
}
