using System;
using DefaultNamespace;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public AbstractUnit unit;

    public Player Owner { get; set; }

    private UnitMovementController movement;


    private void Awake()
    {
        movement = GetComponent<UnitMovementController>();
    }


    public void MoveTo(GameObject tileClicked, Vector3 planePosMouse)
    {
        movement.MoveTo(tileClicked,planePosMouse);
    }
}
