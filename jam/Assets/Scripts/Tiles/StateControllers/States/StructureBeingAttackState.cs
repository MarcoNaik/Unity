namespace Tiles.StateControllers.States
{
    class StructureBeingAttackState : AbstractState
    {
        public StructureBeingAttackState(AbstractTile tile) : base(tile)
        {
        }

        public override void ResolveTurn()
        {
            thisTile.AttackStructure();
        }
    }
}