using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
  public class ButtonReleasedNode : Node
  {
    public InputAction button;
    private bool released = false;

    public ButtonReleasedNode()
    {
      button = new InputAction(metadata.name, InputActionType.Button, "<Gamepad>/buttonSouth");
      button.AddBinding("<Keyboard>/space");
      button.canceled += OnReleased;
      button.Enable();
    }

    ~ButtonReleasedNode()
    {
      button.canceled -= OnReleased;
      button.Disable();
    }
    public override void Tick()
    {
      output = released;
      released = false;
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

    private void OnReleased(InputAction.CallbackContext _ctx)
    {
      released = true;
    }
  }
}
