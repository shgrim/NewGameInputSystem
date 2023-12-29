using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    private GameInputControls controls;
    private void Awake()
    {
        controls = new GameInputControls();
        controls.Player.Enable();
        controls.Player.Interact.performed += Interact_performed;
        controls.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetmovementVector()
    {
        Vector2 inputvector = controls.Player.Move.ReadValue<Vector2>(); ;
        inputvector = inputvector.normalized;
        return inputvector;
    }
}
//Old Input System
/*if (Input.GetKey(KeyCode.W))
{
    inputvector.y += 1;
}
if (Input.GetKey(KeyCode.S))
{
    inputvector.y += -1;
}
if (Input.GetKey(KeyCode.A))
{
    inputvector.x += -1;
}
if (Input.GetKey(KeyCode.D))
{
    inputvector.x += 1;
}*/