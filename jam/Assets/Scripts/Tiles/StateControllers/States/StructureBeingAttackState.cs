using Tiles.States;

namespace Tiles
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