using System;
using UnityEngine;

namespace Units
{
    public class UnitMovementController : MonoBehaviour
    {
        private bool isMovingToTile;
        private Vector3 planeV3;
        
        private Vector3 directionNorm;
        private GameObject tileClicked;

        private AbstractUnit unit;
        private float distance;
        
        private GameObject actualTile;

        [SerializeField] private float velocity;

        private void Awake()
        {
            velocity = 1f;
            unit = GetComponent<UnitController>().unit;
        }

        public void MoveToTile(GameObject tileClicked, Vector3 planePosMouse)
        {
            Debug.Log("tile clicked " + tileClicked);
            Debug.Log("actual tile " + actualTile);
            if (tileClicked == actualTile || !(unit.CurrentMoveRange<=0))
            {
                isMovingToTile = true;
                this.tileClicked = tileClicked;
                planeV3 = (planePosMouse);
            }
        }

        private void FixedUpdate()
        {
            if (isMovingToTile)
            {
                distance = (planeV3-transform.position).magnitude;
                directionNorm = (planeV3-transform.position).normalized;
                if (distance < 0.08f) isMovingToTile = false;
                transform.position += directionNorm * velocity * Time.fixedDeltaTime;
            }
        }
        
        private void OnCollisionStay(Collision other)
        {
            if(other.collider.gameObject.layer == 9 && isMovingToTile)
                StopMovingIfOnTile();
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == 8)
                actualTile = other.gameObject;
            
            
            if(other.gameObject.layer == 9 && isMovingToTile)
                if(isMovingToTile)
                    StopMovingIfOnTile();
        }
        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.layer == 8 && isMovingToTile)
            {
                unit.ExitTile();
                if (unit.CurrentMoveRange <= 0)
                {
                    planeV3 = actualTile.transform.position+ Vector3.up*0.3f;
                }
            }
        }

        private void StopMovingIfOnTile()
        {
            if (actualTile == tileClicked)
            {
                isMovingToTile = false;
            }
        }
        
    }
}
