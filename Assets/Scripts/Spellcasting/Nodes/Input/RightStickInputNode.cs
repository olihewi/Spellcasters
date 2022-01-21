using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
  public class RightStickInputNode : Node
  {
    public override void Tick()
    {
      Vector3 v = StaticInput.input.Gameplay.SecondaryStick.ReadValue<Vector2>();
      value = new Vector3(v.x, 0.0F, v.y);
    }
  }
}
