using System;
using System.Collections;
using System.Collections.Generic;
using Tiles;
using TMPro;
using UI_and_Menus;
using Units;
using UnityEngine;

public class UnitPublicMenu : Refreshable
{
    public UnitController currentUnitController;
    private String type;
    private String ownerName;
    private String maxHp;
    private String currentHp;
    private String powerLevel;

    public GameObject typeTextObject;
    public GameObject ownerNameTextObject;
    public GameObject powerLevelTextObject;
    public GameObject hpTextObject;
    private void OnEnable()
    {
        currentUnitController = GetComponentInParent<UIManager>().currentObject.GetComponent<UnitController>();
        
        ownerName = currentUnitController.Owner.name;

        type = currentUnitController.unit.tag;
        maxHp = currentUnitController.unit.maxHP.ToString();
        powerLevel = currentUnitController.unit.powerLevel.ToString();
        RefreshTexts();
    }

    public override void RefreshTexts()
    {
        currentHp = currentUnitController.unit.CurrentHP.ToString();
        
        typeTextObject.GetComponent<TextMeshProUGUI>().text = type;
        ownerNameTextObject.GetComponent<TextMeshProUGUI>().text = ownerName;
        powerLevelTextObject.GetComponent<TextMeshProUGUI>().text = powerLevel;
        hpTextObject.GetComponent<TextMeshProUGUI>().text = currentHp + " / " + maxHp;
    }
}
