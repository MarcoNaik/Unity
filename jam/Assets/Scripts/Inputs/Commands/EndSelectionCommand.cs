namespace Inputs.Commands
{
    public class EndSelectionCommand: Command
    {
        private RTSUnitManager rtsum;

        private void Awake()
        {
            rtsum = GetComponent<RTSUnitManager>();
        }

        public override void Excecute()
        {
            rtsum.EndUnitSelectionAt(ClickPositionManager.PlanePosMouse());
        }
    }
}