using UnityEngine;

public class ResourceInventory  : MonoBehaviour
{
   
    public int Materials { get; private set; }
    public int Food { get; private set; }

    public void addMaterials(int amount)
    {
        Materials+=amount;
    }

    public void addFood(int amount)
    {
        Food += amount;
    }

    public void removeFood(int unitCost)
    {
        Food -= unitCost;
    }
}