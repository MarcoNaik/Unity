using System;
using UnityEngine;

public class UnitMovementController : MonoBehaviour
{
    private bool ismoving;
    private Vector3 planeV3;
    private Vector3 directionNorm;
    private GameObject tileClicked;
    private float distance;

    [SerializeField] private float velocity;

    private void Awake()
    {
        velocity = 1f;
    }

    public void MoveTo(GameObject tileClicked, Vector3 planePosMouse)
    {
        Debug.Log("vectorClikeao" + planePosMouse);
        ismoving = true;
        this.tileClicked = tileClicked;
        planeV3 = (planePosMouse);
    }

    private void FixedUpdate()
    {
        if (ismoving)
        {
            float distance = (planeV3-transform.position).magnitude;
            directionNorm = (planeV3-transform.position).normalized;
            Debug.Log(distance);
            if (distance < 0.15f) ismoving = false;
            transform.position += directionNorm * velocity * Time.fixedDeltaTime;
        }
        
    }

    private void OnCollision(Collision other)
    {
        StopMovingIfOnTile(other);
    }
    private void OnCollisionEnter(Collision other)
    {
        StopMovingIfOnTile(other);
    }

    private void StopMovingIfOnTile(Collision other)
    {
        if (other.collider.gameObject.layer == 9 && ismoving)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position , Vector3.down, out hit, 10f, 8))
            {
                if (hit.collider.gameObject == tileClicked)
                {
                    ismoving = false;
                }
            }
            
        }
    }
}
