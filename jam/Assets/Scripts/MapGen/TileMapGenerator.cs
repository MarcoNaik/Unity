using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGenerator : MonoBehaviour
{
    public Distribution distribution;

    public int height;
    public int width;
    public bool pickByPercentage;
    
    private int mapSize;

    public void GenerateMap()
    {
        List<Distribution.Prefabs> distributionBackUp = distribution.GetPrebList();
        mapSize = (width + 1) * (2 * height - width) - height;
        GenMapRecursion(height, width, 0, transform.position,pickByPercentage);
        distribution.SetPrefabList(distributionBackUp);
    }
    
    public void GenMapRecursion(int height, int width, int whichWay, Vector3 position, bool pickByPercentage)
    {
        
        if (width >= height) width = height - 1;
        if (width == -1) return;
        GameObject tempGO;

        for (int i = 0; i < height; i++)
        {
            if(pickByPercentage)
            {
                tempGO = Instantiate(distribution.PickByPercentage());
            }
            else
            {
                tempGO = Instantiate(distribution.PickByQuantity(mapSize));
                mapSize--;
            }
            tempGO.transform.position = position + new Vector3(i, 0, 0);
        }

        switch (whichWay)
        {
            case 0: 
                GenMapRecursion(height-1, width-1, 1, position + new Vector3((float) 0.5, 0, (float) 0.865) , pickByPercentage);
                GenMapRecursion(height-1, width-1, -1, position + new Vector3((float) 0.5, 0, (float) -0.865) , pickByPercentage );
                break;
            case 1:
                GenMapRecursion(height-1, width-1, 1, position + new Vector3((float) 0.5, 0, (float) 0.865) , pickByPercentage );
                break;
            case -1:
                GenMapRecursion(height-1, width-1, -1, position + new Vector3((float) 0.5, 0, (float) -0.865) , pickByPercentage );
                break;
            
        }
    }

  
}
