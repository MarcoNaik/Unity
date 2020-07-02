// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Inputs
{
    public class @InputManager : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputManager()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Turn"",
            ""id"": ""f1f34dc9-ec0e-4e73-92d8-5d14e1d57d99"",
            ""actions"": [
                {
                    ""name"": ""SingleClick"",
                    ""type"": ""Button"",
                    ""id"": ""4d280e68-0da7-4806-a46f-25c753814b0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.1,pressPoint=0.01)""
                },
                {
                    ""name"": ""EndUnitSelection"",
                    ""type"": ""Button"",
                    ""id"": ""92af4035-58b7-40c4-aa69-a666be1a1931"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""SlowTap(duration=0.10001,pressPoint=0.01)""
                },
                {
                    ""name"": ""StartUnitSelection"",
                    ""type"": ""Button"",
                    ""id"": ""68528ca4-465b-4748-8034-3f6abfe91ba6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""d5a4525d-c027-4027-a793-d2664e892a67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a7e20da9-8291-4f66-a180-42f097d9e92c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SingleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff9add4a-46f5-4c33-a8a2-61c0785713e9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SingleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78d415bb-0e36-44eb-845a-775e6fae281d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EndUnitSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60a2d1b5-901d-4a00-85b0-5f1de54f3967"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartUnitSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7233102-fce5-40f4-85f1-3208ef3fd3c4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Turn
            m_Turn = asset.FindActionMap("Turn", throwIfNotFound: true);
            m_Turn_SingleClick = m_Turn.FindAction("SingleClick", throwIfNotFound: true);
            m_Turn_EndUnitSelection = m_Turn.FindAction("EndUnitSelection", throwIfNotFound: true);
            m_Turn_StartUnitSelection = m_Turn.FindAction("StartUnitSelection", throwIfNotFound: true);
            m_Turn_RightClick = m_Turn.FindAction("RightClick", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Turn
        private readonly InputActionMap m_Turn;
        private ITurnActions m_TurnActionsCallbackInterface;
        private readonly InputAction m_Turn_SingleClick;
        private readonly InputAction m_Turn_EndUnitSelection;
        private readonly InputAction m_Turn_StartUnitSelection;
        private readonly InputAction m_Turn_RightClick;
        public struct TurnActions
        {
            private @InputManager m_Wrapper;
            public TurnActions(@InputManager wrapper) { m_Wrapper = wrapper; }
            public InputAction @SingleClick => m_Wrapper.m_Turn_SingleClick;
            public InputAction @EndUnitSelection => m_Wrapper.m_Turn_EndUnitSelection;
            public InputAction @StartUnitSelection => m_Wrapper.m_Turn_StartUnitSelection;
            public InputAction @RightClick => m_Wrapper.m_Turn_RightClick;
            public InputActionMap Get() { return m_Wrapper.m_Turn; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TurnActions set) { return set.Get(); }
            public void SetCallbacks(ITurnActions instance)
            {
                if (m_Wrapper.m_TurnActionsCallbackInterface != null)
                {
                    @SingleClick.started -= m_Wrapper.m_TurnActionsCallbackInterface.OnSingleClick;
                    @SingleClick.performed -= m_Wrapper.m_TurnActionsCallbackInterface.OnSingleClick;
                    @SingleClick.canceled -= m_Wrapper.m_TurnActionsCallbackInterface.OnSingleClick;
                    @EndUnitSelection.started -= m_Wrapper.m_TurnActionsCallbackInterface.OnEndUnitSelection;
                    @EndUnitSelection.performed -= m_Wrapper.m_TurnActionsCallbackInterface.OnEndUnitSelection;
                    @EndUnitSelection.canceled -= m_Wrapper.m_TurnActionsCallbackInterface.OnEndUnitSelection;
                    @StartUnitSelection.started -= m_Wrapper.m_TurnActionsCallbackInterface.OnStartUnitSelection;
                    @StartUnitSelection.performed -= m_Wrapper.m_TurnActionsCallbackInterface.OnStartUnitSelection;
                    @StartUnitSelection.canceled -= m_Wrapper.m_TurnActionsCallbackInterface.OnStartUnitSelection;
                    @RightClick.started -= m_Wrapper.m_TurnActionsCallbackInterface.OnRightClick;
                    @RightClick.performed -= m_Wrapper.m_TurnActionsCallbackInterface.OnRightClick;
                    @RightClick.canceled -= m_Wrapper.m_TurnActionsCallbackInterface.OnRightClick;
                }
                m_Wrapper.m_TurnActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @SingleClick.started += instance.OnSingleClick;
                    @SingleClick.performed += instance.OnSingleClick;
                    @SingleClick.canceled += instance.OnSingleClick;
                    @EndUnitSelection.started += instance.OnEndUnitSelection;
                    @EndUnitSelection.performed += instance.OnEndUnitSelection;
                    @EndUnitSelection.canceled += instance.OnEndUnitSelection;
                    @StartUnitSelection.started += instance.OnStartUnitSelection;
                    @StartUnitSelection.performed += instance.OnStartUnitSelection;
                    @StartUnitSelection.canceled += instance.OnStartUnitSelection;
                    @RightClick.started += instance.OnRightClick;
                    @RightClick.performed += instance.OnRightClick;
                    @RightClick.canceled += instance.OnRightClick;
                }
            }
        }
        public TurnActions @Turn => new TurnActions(this);
        public interface ITurnActions
        {
            void OnSingleClick(InputAction.CallbackContext context);
            void OnEndUnitSelection(InputAction.CallbackContext context);
            void OnStartUnitSelection(InputAction.CallbackContext context);
            void OnRightClick(InputAction.CallbackContext context);
        }
    }
}
