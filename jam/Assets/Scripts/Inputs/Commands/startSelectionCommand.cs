using UnityEngine;

public class StartSelectionCommand: Command
{
    private RTSUnitManager rtsum;

    private void Awake()
    {
        rtsum = GetComponent<RTSUnitManager>();
    }

    public override void Excecute()
    {
        rtsum.StartUnitSelectionAt(ClickPositionManager.PlanePosMouse());
    }
}
