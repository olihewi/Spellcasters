using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
  public class ButtonReleasedNode : Node
  {
    public override void Tick()
    {
      output = Keyboard.current.spaceKey.wasReleasedThisFrame ? 1.0F : 0.0F;
    }
  }
}
