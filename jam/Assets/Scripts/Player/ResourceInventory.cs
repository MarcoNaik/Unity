using UnityEngine;

namespace Player
{
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

        private void Awake()
        {
            Food = 1000;
            Materials = 1000;
        }

        public void removeMaterials(int structureCost)
        {
            Materials -= structureCost;
        }
    }
}