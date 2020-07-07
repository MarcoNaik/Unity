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
        public String prefabTag;
    }
    
    public List<MenusPrefabs> privateMenusPrefabs;
    public List<MenusPrefabs> publicMenusPrefabs;

    private Dictionary<String, GameObject> poolPrivatesMenus;
    private Dictionary<String, GameObject> poolPublicMenus;

    private GameObject currentPrivateMenu;
    public GameObject currentPublicMenu;
    
    public GameObject currentObject;
    
    

    private void Awake()
    {
        poolPrivatesMenus = new Dictionary<string, GameObject>();
        poolPublicMenus = new Dictionary<string, GameObject>();
    }


    private void Start()
    {
        foreach (MenusPrefabs menuPrefab in privateMenusPrefabs)
        {
            currentPrivateMenu = Instantiate(menuPrefab.prefab, transform, false);
            currentPrivateMenu.SetActive(false);
            poolPrivatesMenus.Add(menuPrefab.prefabTag ,currentPrivateMenu);
        }
        
        foreach (MenusPrefabs menuPrefab in publicMenusPrefabs)
        {
            currentPublicMenu = Instantiate(menuPrefab.prefab, transform, false);
            currentPublicMenu.SetActive(false);
            poolPublicMenus.Add(menuPrefab.prefabTag ,currentPublicMenu);
        }
    }
    

    public void DisplayBothMenus(GameObject objectToDisplayMenu, String publicMenuKey)
    {
        String key = objectToDisplayMenu.tag;
        
        currentObject = objectToDisplayMenu;
        TurnOffCurentMenus();
        if (poolPrivatesMenus.ContainsKey(key))
        {
            currentPrivateMenu = poolPrivatesMenus[key];
            currentPrivateMenu.SetActive(true);
        }
        currentPublicMenu = poolPublicMenus[publicMenuKey];
        currentPublicMenu.SetActive(true);
        
    }

    public void TurnOffCurentMenus()
    {
        currentPrivateMenu.SetActive(false);
        currentPublicMenu.SetActive(false);
    }

    public void DisplayPublicMenu(GameObject objectToDisplayMenu, String publicMenuKey)
    {
        String key = publicMenuKey;
        
        currentObject = objectToDisplayMenu;
        TurnOffCurentMenus();
        currentPublicMenu = poolPublicMenus[key];
        currentPublicMenu.SetActive(true);
        
    }
}