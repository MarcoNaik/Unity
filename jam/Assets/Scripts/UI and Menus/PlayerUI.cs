using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI_and_Menus;
using Units;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public Player player;
    private String playerName;
    private String food;
    private String materials;

    public GameObject playerNameTextObject;
    public GameObject foodTextObject;
    public GameObject materialsTextObject;

    public int playerIndex;
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
        
        foodTextObject.GetComponent<TextMeshProUGUI>().text = food;
        materialsTextObject.GetComponent<TextMeshProUGUI>().text = materials;
    }
}
