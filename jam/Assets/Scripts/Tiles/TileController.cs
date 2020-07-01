using System;
using DefaultNamespace;
using UnityEngine;



public class TileController : MonoBehaviour
{ 
    public AbstractTile tile;
    public Player Owner { get; set; }

    public ITileState tileState;

    public StateController stateController;

    private void Awake()
    {
        Owner = null;
    }
    
    
    public void EndTurn()
    {
        tile.RefreshIUnitList();
        tileState.ResolveTurn();
        stateController.CheckState();
    }
    private void OnCollisionEnter(Collision other)
    {
    
        if (other.gameObject.layer == 9) tile.UnitsOnTop.Add(other.gameObject);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == 9) tile.UnitsOnTop.Remove(other.gameObject);
    }
}
