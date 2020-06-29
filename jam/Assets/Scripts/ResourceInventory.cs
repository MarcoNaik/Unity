using UnityEngine;

namespace DefaultNamespace
{
    public class ResourceInventory  : MonoBehaviour
    {
        [SerializeField]
        private int materials;
        [SerializeField]
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