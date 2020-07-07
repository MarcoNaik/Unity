namespace Inputs.Commands
{
    public class EndSelectionCommand: Command
    {
        private RTSUnitManager rtsum;
        private UIManager ui;

        private void Awake()
        {
            rtsum = GetComponent<RTSUnitManager>();
            ui = GetComponentInParent<UIManager>();
        }

        public override void Excecute()
        {
            rtsum.EndUnitSelectionAt(ClickPositionManager.PlanePosMouse());
            ui.TurnOffCurentMenus();
        }
    }
}