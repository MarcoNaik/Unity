namespace Inputs.Commands.BuildingCommands
{
    public class BuildFactoryCommand : Command
    {
        private RTSUnitManager rtsum;
    
        private void Awake()
        {
            rtsum = GetComponent<RTSUnitManager>();
        }
        public override void Excecute()
        {
            rtsum.Build(ClickPositionManager.TileClicked(), ClickPositionManager.PlanePosMouse(), "Factory",400);
            GetComponent<CancelBuildingComand>().Excecute();
        }
    }
}