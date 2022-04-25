using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
  public class DirectionInputNode : Node
  {
    public InputAction direction;
    private Vector2 value = Vector2.zero;

    public DirectionInputNode()
    {
      direction = new InputAction(metadata.name, InputActionType.Value, "<Gamepad>/leftStick");
      direction.expectedControlType = "Stick";
      direction.performed += OnPerformed;
      direction.canceled += OnPerformed;
      direction.Enable();
    }

    ~DirectionInputNode()
    {
      direction.performed -= OnPerformed;
      direction.canceled -= OnPerformed;
      direction.Disable();
    }
    public override void Tick()
    {
      output = new Vector3(value.x,0.0F,value.y);
    }

    public override void OnSelectedInGrid()
    {
      Debug.Log("Performing Interactive Rebind!");
      direction.Disable();
      direction.PerformInteractiveRebinding().OnApplyBinding(OnRebind).Start();
    }

    private void OnRebind(InputActionRebindingExtensions.RebindingOperation _ctx, string _newBind)
    {
      _ctx.action.Enable();
      Debug.Log($"Rebound {_ctx.action.name} to {_newBind}");
      direction.ChangeBinding(0).To(new InputBinding(_newBind));
    }

    private void OnPerformed(InputAction.CallbackContext _ctx)
    {
      value = _ctx.ReadValue<Vector2>();
    }
  }
}
