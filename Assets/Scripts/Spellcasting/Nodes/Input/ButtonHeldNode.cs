using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Spellcasting.Nodes.Input
{
  public class ButtonHeldNode : Node
  {
    public KeyControl keyboardKey;
    public ButtonControl gamepadButton;

    public override void Tick()
    {
      value = (keyboardKey != null && keyboardKey.isPressed) | (gamepadButton != null && gamepadButton.isPressed) ? 1.0F : 0.0F;
    }
    public override void OnSelectedInGrid()
    {
      if (Keyboard.current != null)
      {
        foreach (KeyControl key in Keyboard.current.allKeys)
        {
          if (key.wasPressedThisFrame)
          {
            if (key == Keyboard.current.tabKey) return;
            keyboardKey = key;
            return;
          }
        }
      }

      if (Gamepad.current != null)
      {
        foreach (ButtonControl button in Gamepad.current.allControls)
        {
          if (button.wasPressedThisFrame)
          {
            gamepadButton = button;
            return;
          }
        }
      }
    }
    public override string GetIconString()
    {
      return keyboardKey != null ? keyboardKey.displayName[0].ToString().ToUpper() + keyboardKey.displayName.Substring(1).ToLower() : "";
    }
  }
}
