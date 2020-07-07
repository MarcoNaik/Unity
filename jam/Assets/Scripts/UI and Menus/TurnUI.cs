using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
