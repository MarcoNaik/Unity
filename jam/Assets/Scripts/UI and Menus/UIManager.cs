using System;
using System.Collections.Generic;
using Tiles;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [System.Serializable]
    public struct MenusPrefabs
    {
        public GameObject prefab;
        public String prefabName;
    }
    public List<MenusPrefabs> menusPrefabs;

    private Dictionary<String, GameObject> poolMenus;

    private GameObject currentMenu;
    
    public GameObject currentObject;
    
    

    private void Awake()
    {
        poolMenus = new Dictionary<string, GameObject>();
    }


    private void Start()
    {
        foreach (MenusPrefabs menuPrefab in menusPrefabs)
        {
            currentMenu = Instantiate(menuPrefab.prefab, transform, false);
            currentMenu.SetActive(false);
            poolMenus.Add(menuPrefab.prefabName ,currentMenu);
        }
    }
    

    public void DisplayMenu(GameObject objectToDisplayMenu)
    {
        String key = objectToDisplayMenu.tag;
        if (objectToDisplayMenu.GetComponent<TileController>().Owner ==
            FindObjectOfType<GameController>().thisTurnPlayer)
        {
            currentObject = objectToDisplayMenu;
            currentMenu.SetActive(false);
            currentMenu = poolMenus[key];
            currentMenu.SetActive(true);
        }
    }

    public void TurnOffCurentMenu()
    {
        if(currentMenu!=null)
            currentMenu.SetActive(true);
    }
}