using UnityEngine;

namespace Tiles.Utilities
{
   public class Borders : MonoBehaviour
   {
      public Vector3 position;

      private void Awake()
      {
         position = transform.position;
      }
   }
}
