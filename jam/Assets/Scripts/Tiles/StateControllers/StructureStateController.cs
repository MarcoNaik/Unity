using Tiles.StateControllers.States;

namespace Tiles.StateControllers
{
    public class StructureStateController : AbstractStateController
    {
        protected override void SetState(int stateId)
        {
            switch (stateId)
            {
                case 0:
                    SetPacificStructureState();
                    return;
                case 1:
                    SetPacificStructureState();
                    return;
                case 2:
                    SetStructureBeingAttackedState();
                    return;
                case 3:
                    SetStructureCombatState();
                    return;
                case 4:
                    SetPacificStructureState();
                    return;
                case 5:
                    SetPacificStructureState();
                    return;
                case 6:
                    SetStructureCombatState();
                    return;
                case 7:
                    SetStructureCombatState();
                    return;
            }
        }

        private void SetStructureCombatState()
        {
            tileController.tileState =new StructureCombatState(tileController.tile);
        }

        private void SetStructureBeingAttackedState()
        {
            tileController.tileState =new StructureBeingAttackState(tileController.tile);
        }

        private void SetPacificStructureState()
        {
            tileController.tileState =new StructurePacificState(tileController.tile);

        }
    }
}