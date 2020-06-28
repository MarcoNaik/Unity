using UnityEngine;

namespace DefaultNamespace
{
    public class ResourceInventory  : MonoBehaviour
    {
        private int materials;
        private int food;

        public void addMaterials(int amount)
        {
            materials+=amount;
        }

        public void addFood(int amount)
        {
            food += amount;
        }
    }
}