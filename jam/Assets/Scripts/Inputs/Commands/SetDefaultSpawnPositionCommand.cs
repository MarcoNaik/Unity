using Tiles.TileTypes.Structures;

namespace Inputs.Commands
{
    public class SetDefaultSpawnPositionCommand : Command
    {
        public AbstractStructure structure;
        

        public override void Excecute()
        {
            structure.SetSpawnPosTo(ClickPositionManager.TileClicked(), ClickPositionManager.PlanePosMouse());
        }
    }
}