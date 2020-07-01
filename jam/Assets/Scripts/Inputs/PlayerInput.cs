using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, ITapInput
{
    private InputManager inputManager;
    
    public Command tapInput;
    public Command startSelectionInput;
    public Command endSelectionInput;
    public Command rightClickInput;
    public bool IsTaping { get; private set; }

    private void Awake()
    {
        inputManager = new InputManager();
    }

    private void OnEnable()
    {
        inputManager.Turn.SingleClick.performed += OnSingleClick;
        inputManager.Turn.StartUnitSelection.performed += OnStartUnitSelection;
        inputManager.Turn.EndUnitSelection.performed += OnEndUnitSelection;
        inputManager.Turn.RightClick.performed += OnRightClick;
        inputManager.Enable();
    }
    private void OnDisable()
    {
        inputManager.Turn.SingleClick.performed -= OnSingleClick;
        inputManager.Disable();
    }

    private void OnStartUnitSelection(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        Debug.Log("we are starting holding"); 
        if (startSelectionInput != null)
        {
            startSelectionInput.Excecute();
        }
    }

    private void OnEndUnitSelection(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        Debug.Log("we have ended holding click"); 
        if (endSelectionInput!= null)
        {
            endSelectionInput.Excecute();
        }
    }

    private void OnRightClick(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        Debug.Log("we are right clicking"); 
        if (rightClickInput != null)
        {
            rightClickInput.Excecute();
        }
    }
    private void OnSingleClick(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        Debug.Log("we are tapping"); 
        if (tapInput != null)
        {
            tapInput.Excecute();
        }
    }
    

    
}