namespace Inputs.Commands
{
    public class MoveUnitsCommand : Command
    {
        private RTSUnitManager rtsum;
    
        private void Awake()
        {
            rtsum = GetComponent<RTSUnitManager>();
        }

        public override void Excecute()
        {
            rtsum.MoveUnitsTo(ClickPositionManager.TileClicked(), ClickPositionManager.PlanePosMouse());
        }
    }
}
