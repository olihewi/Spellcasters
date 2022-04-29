using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
  public class ButtonHeldNode : Node
  {
    public InputAction button;
    private bool held = false;

    public ButtonHeldNode()
    {
      button = new InputAction(metadata.name, InputActionType.Button, "<Gamepad>/buttonSouth");
      button.AddBinding("<Keyboard>/space");
      button.started += OnPressed;
      button.canceled += OnReleased;
      button.Enable();
    }

    ~ButtonHeldNode()
    {
      button.started += OnPressed;
      button.canceled -= OnReleased;
      button.Disable();
    }
    public override void Tick()
    {
      output = held;
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
      held = true;
    }
    private void OnReleased(InputAction.CallbackContext _ctx)
    {
      held = false;
    }
  }
}
