using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
  public class ButtonPressedNode : Node
  {
    public InputAction button;
    private bool pressed = false;

    public ButtonPressedNode()
    {
      button = new InputAction(metadata.name, InputActionType.Button, "<Gamepad>/buttonSouth");
      button.AddBinding("<Keyboard>/space");
      button.started += OnPressed;
      button.Enable();
    }
    ~ButtonPressedNode()
    {
      button.started -= OnPressed;
      button.Disable();
    }
    
    public override void Tick()
    {
      output = pressed;
      pressed = false;
    }

    public override void OnSelectedInGrid()
    {
      Debug.Log("Performing Interactive Rebind!");
      button.Disable();
      button.PerformInteractiveRebinding().OnApplyBinding(OnRebind).Start();
    }

    private void OnRebind(InputActionRebindingExtensions.RebindingOperation _ctx, string _newBind)
    {
      _ctx.action.Enable();
      Debug.Log($"Rebound {_ctx.action.name} to {_newBind}");
    }

    private void OnPressed(InputAction.CallbackContext _ctx)
    {
      pressed = true;
    }
  }
}
