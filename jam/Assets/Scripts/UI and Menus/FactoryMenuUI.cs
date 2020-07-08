using System.Collections;
using System.Collections.Generic;
using Tiles;
using UI_and_Menus;
using UnityEngine;

public class FactoryMenuUI : MonoBehaviour
{
    private Factory currentFactory;
    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        currentFactory = (Factory) GetComponentInParent<UIManager>().currentObject.GetComponent<TileController>().tile;
    }

    public void SpawnAttackUnitButton()
    {
        currentFactory.SpawnAttackMinion();
        gameController.RefreshPlayersUI();

    }
}
