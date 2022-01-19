using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Constants
{
  public class ConstantNumberNode : Node
  {
    public ConstantNumberNode()
    {
      value = 1.0F;
    }
    public override void OnSelectedInGrid()
    {
      if (Mouse.current.leftButton.wasPressedThisFrame)
      {
        value = (float)value + (Keyboard.current.leftShiftKey.isPressed ? -1.0F : 1.0F);
        UnityEngine.Debug.Log((float)value);
      }
    }
  }
}

