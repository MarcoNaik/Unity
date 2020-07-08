namespace Inputs.Commands.BuildingCommands
{
    public class CancelBuildingComand : Command
    {
        private PlayerInput playerInput;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
        }

        public override void Excecute()
        {
            playerInput.startSelectionInput = GetComponent<StartSelectionCommand>();
            playerInput.rightClickInput = GetComponent<MoveUnitsCommand>();
        }
    }
}
