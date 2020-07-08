using Inputs;
using Inputs.Commands.BuildingCommands;
using Units;
using UnityEngine;

namespace UI_and_Menus
{
    public class VilagerUnitUI : MonoBehaviour
    {
        private UnitController currentVillager;
        private GameController gameController;
        private PlayerInput playerInputs;
    

        private void Awake()
        {
            gameController = FindObjectOfType<GameController>();
            playerInputs = gameController.GetComponentInChildren<PlayerInput>();
        }

        private void OnEnable()
        {
            currentVillager = GetComponentInParent<UIManager>().currentObject.GetComponent<UnitController>();
        }

        public void BuildVillageButton()
        {
            if (currentVillager.Owner.resourceManager.Materials > 850) // aun nose como hacer eso bns xd
            {
                playerInputs.startSelectionInput = playerInputs.GetComponent<BuildVillageCommand>();
                playerInputs.rightClickInput = playerInputs.GetComponent<CancelBuildingComand>();
                
            }
        }
        
        public void BuildFactoryButton()
        {
            if (currentVillager.Owner.resourceManager.Materials > 500) // aun nose como hacer eso bns xd
            {
                playerInputs.startSelectionInput = playerInputs.GetComponent<BuildFactoryCommand>();
                playerInputs.rightClickInput = playerInputs.GetComponent<CancelBuildingComand>();
                
            }

        }
    }
}

