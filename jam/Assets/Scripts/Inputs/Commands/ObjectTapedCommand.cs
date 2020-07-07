using Tiles;
using Tiles.TileTypes.Structures;
using Units;
using UnityEngine;
using UnityEngine.WSA;

namespace Inputs.Commands
{
    public class ObjectTapedCommand : Command
    {
        private RTSUnitManager rtsum;
        private UIManager ui;
        private GameController gameController;

        private void Awake()
        {
            rtsum = GetComponent<RTSUnitManager>();
            ui = GetComponentInParent<UIManager>();
            gameController = FindObjectOfType<GameController>();
        }

        public override void Excecute()
        {
            GetComponent<DrawSquare>().enabled = false;
            GameObject taped = ClickPositionManager.ObjectClicked();
            
            Debug.Log("we tapped " + taped);
            
            if (taped==null) return;
            
            if (taped.layer == 9) //unit
            {
                if (taped.GetComponent<UnitController>().Owner == gameController.CurrentPlayer)
                {
                    ui.DisplayBothMenus(taped,"Unit");
                }
                else
                {
                    ui.DisplayPublicMenu(taped, "Unit");
                }
                rtsum.AddUnitByTap(taped);
            }
            if (taped.layer == 8) //hex
            {
                rtsum.UnShowSelectedUI();
                
                if (taped.GetComponent<TileController>().Owner == gameController.CurrentPlayer)
                {
                    ui.DisplayBothMenus(taped,"Tile");
                }
                else
                {
                    ui.DisplayPublicMenu(taped,"Tile");
                }
                AbstractStructure structure = taped.GetComponent<AbstractStructure>();

                if (structure != null)
                {
                    SetDefaultSpawnPositionCommand spawnPosCommand = GetComponent<SetDefaultSpawnPositionCommand>();
                    spawnPosCommand.structure = structure;
                    Debug.Log("we have currently entered to the right click set position mode");
                    GetComponent<PlayerInput>().rightClickInput = spawnPosCommand;
                }
            }
        }
    }
}
