namespace Inputs.Commands.BuildingCommands
{
    public class BuildVillageCommand : Command
    {
        private RTSUnitManager rtsum;
    
        private void Awake()
        {
            rtsum = GetComponent<RTSUnitManager>();
        }
        public override void Excecute()
        {
            rtsum.Build(ClickPositionManager.TileClicked(), ClickPositionManager.PlanePosMouse(), "Village",850);
            GetComponent<CancelBuildingComand>().Excecute();
        }
    }
}
