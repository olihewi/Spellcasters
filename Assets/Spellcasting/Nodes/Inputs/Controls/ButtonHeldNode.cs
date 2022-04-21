using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
  public class ButtonHeldNode : Node
  {
    public InputAction binding;

    private void Awake()
    {
      binding.AddBinding("<Keyboard>/space");
      binding.AddBinding("<Gamepad>/buttonSouth");
    }
    private void OnEnable()
    {
      binding.Enable();
      binding.started += _ctx => held = true;
      binding.canceled += _ctx => held = false;
    }
    private void OnDisable()
    {
      binding.Disable();
    }

    private bool held = false;

    public override void Tick()
    {
      output = held;
    }
  }
}