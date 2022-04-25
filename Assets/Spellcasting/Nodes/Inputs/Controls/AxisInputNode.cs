using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
  public class AxisInputNode : Node
  {
    public InputAction axis;
    private float value = 0.0F;

    public AxisInputNode()
    {
      axis = new InputAction(metadata.name, InputActionType.Value, "<Gamepad>/rightTrigger");
      axis.expectedControlType = "Axis";
      axis.AddBinding("<Keyboard>/space");
      axis.performed += OnPerformed;
      axis.canceled += OnPerformed;
      axis.Enable();
    }

    ~AxisInputNode()
    {
      axis.performed -= OnPerformed;
      axis.canceled -= OnPerformed;
      axis.Disable();
    }
    public override void Tick()
    {
      output = value;
    }

    public override void OnSelectedInGrid()
    {
      Debug.Log("Performing Interactive Rebind!");
      axis.Disable();
      axis.PerformInteractiveRebinding().OnApplyBinding(OnRebind).Start();
    }

    private void OnRebind(InputActionRebindingExtensions.RebindingOperation _ctx, string _newBind)
    {
      _ctx.action.Enable();
      Debug.Log($"Rebound {_ctx.action.name} to {_newBind}");
    }

    private void OnPerformed(InputAction.CallbackContext _ctx)
    {
      value = _ctx.ReadValue<float>();
    }
  }
}
