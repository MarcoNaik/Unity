using UnityEngine;

namespace Inputs
{
    public class ClickPositionManager : MonoBehaviour
    {
        public static  Vector3 PlanePosMouse()
        {
            Vector3 pos = Vector3.zero;
            Plane plane = new Plane(Vector3.up, new Vector3(0,(float) 0.3,0));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;
            if (plane.Raycast(ray, out distanceToPlane))
            {
                pos =ray.GetPoint(distanceToPlane);
            }
            return pos;
        }

        public static GameObject ObjectClicked()
        {
            GameObject objectClicked= null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,100))
            {
                objectClicked = hit.collider.gameObject;
            }
            return objectClicked;
        }
    
        public static GameObject TileClicked()
        {
            GameObject objectClicked= null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,100,1 << 8))
            {
                objectClicked = hit.collider.gameObject;
            }
            return objectClicked;
        }
    }
}
