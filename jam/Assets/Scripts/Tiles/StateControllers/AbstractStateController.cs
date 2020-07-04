using UnityEngine;

namespace Tiles
{
    public abstract class AbstractStateController : MonoBehaviour
    {
        protected TileController tileController;

        private void Awake()
        {
            tileController = GetComponent<TileController>();
        }

        public void CheckState()
        {
            var tile = tileController.tile;

            var stateId = 0;
            var def = Picker.UnitAlive(tile.Defenders);
            var gath = Picker.UnitAlive(tile.Gatherers);
            var att = Picker.UnitAlive(tile.EnemyAtackers);

            if (def != null) stateId += 1;
            if (att != null) stateId += 2;
            if (gath != null) stateId += 4;

            SetState(stateId);
        }

        protected abstract void SetState(int stateId);
    }
}