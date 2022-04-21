using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
  public class StickInputNode : Node
  {
    public InputAction up;
    public InputAction down;
    public InputAction left;
    public InputAction right;
    public override void Tick()
    {
      Vector3 v = new Vector3(right.ReadValue<float>() - left.ReadValue<float>(), 0.0F, up.ReadValue<float>() - down.ReadValue<float>());
      v.Normalize();
      output = v;
    }
  }
}
