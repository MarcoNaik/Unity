﻿using Tiles.TileTypes.Structures;
using UnityEngine;

namespace Inputs.Commands
{
    public class ObjectTapedCommand : Command
    {
        private RTSUnitManager rtsum;

        private void Awake()
        {
            rtsum = GetComponent<RTSUnitManager>();
        }

        public override void Excecute()
        {
            GetComponent<DrawSquare>().enabled = false;
            GameObject taped = ClickPositionManager.ObjectClicked();
            
            Debug.Log("we tapped " + taped);
            
            if (taped==null) return;
            
            if (taped.layer == 9)
            {
                rtsum.AddUnitByTap(taped);
            }
            if (taped.layer == 8)
            {
                AbstractStructure structure = taped.GetComponent<AbstractStructure>();

                if (structure != null)
                {
                    SetDefaultSpawnPositionCommand spawnPosCommand = GetComponent<SetDefaultSpawnPositionCommand>();
                    spawnPosCommand.structure = structure;
                    GetComponent<PlayerInput>().rightClickInput = spawnPosCommand;
                }
            }
        }
    }
}
