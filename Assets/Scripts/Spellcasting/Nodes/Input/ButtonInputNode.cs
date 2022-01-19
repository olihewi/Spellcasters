using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
  public class ButtonPressedNode : Node
  {
    public override void Tick()
    {
      value = Keyboard.current.spaceKey.wasPressedThisFrame ? 1.0F : 0.0F;
    }
  }
}
