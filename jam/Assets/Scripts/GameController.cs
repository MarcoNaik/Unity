using System;
using System.Collections;
using System.Collections.Generic;
using MapGen;
using Tiles;
using UI_and_Menus;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player[] players;
    

    public Player CurrentPlayer;
    private TileMapGenerator mapGenerator;

    public UIManager UiManager;
    public PlayerUI player1UI;
    public Material player1Material;
    public Material player2Material;
    public PlayerUI player2UI;
    public TurnUI currentPlayerUI;
    
    private List<GameObject> hexMap;
    public static int turn;
    
    
    private Dictionary<Player, Material> playerMaterialDictionary;
    private void Awake()
    {
        playerMaterialDictionary = new Dictionary<Player, Material>();
        
        players[0] = Instantiate(players[0],transform);
        players[1] = Instantiate(players[1],transform);
        
  
        
        playerMaterialDictionary.Add(players[1], player1Material);
        playerMaterialDictionary.Add(players[0], player2Material);
        
        hexMap = new List<GameObject>();
        mapGenerator = GetComponentInChildren<TileMapGenerator>();
        CurrentPlayer = players[1];
        turn = 1;
    }

    private void Start()
    {
        mapGenerator.GenerateMap();
    }

    public void EndTurn()
    {
        HexGlobalEndTurn();
        turn++;
        player1UI.RefreshTexts();
        player2UI.RefreshTexts();
        CurrentPlayer = players[turn % 2];
        currentPlayerUI.RefreshTexts();
        UiManager.currentPublicMenu.GetComponent<Refreshable>().RefreshTexts();
    }

    public void RefreshPlayersUI()
    {
        player1UI.RefreshTexts();
        player2UI.RefreshTexts();
    }

    private void HexGlobalEndTurn()
    {
        foreach (GameObject tile in hexMap)
        {
            tile.GetComponent<TileController>().EndTurn();
        }
    }
    public void AddHex(GameObject hex)
    {
        hexMap.Add(hex);
    }

    public Material CurrentPlayerMaterial()
    {
        return playerMaterialDictionary[CurrentPlayer];
    }
}