using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Constants
{
  public class ConstantNumberNode : Node
  {
    public string stringInput = "";
    public ConstantNumberNode()
    {
      value = 1.0F;
    }
    public override void OnSelectedInGrid()
    {
      // This mess is actually easier than using Keyboard.onTextInput but I hate it.
      Keyboard kb = Keyboard.current;
      if (kb.digit0Key.wasPressedThisFrame || kb.numpad0Key.wasPressedThisFrame)
        stringInput += "0";
      if (kb.digit1Key.wasPressedThisFrame || kb.numpad1Key.wasPressedThisFrame)
        stringInput += "1";
      if (kb.digit2Key.wasPressedThisFrame || kb.numpad2Key.wasPressedThisFrame)
        stringInput += "2";
      if (kb.digit3Key.wasPressedThisFrame || kb.numpad3Key.wasPressedThisFrame)
        stringInput += "3";
      if (kb.digit4Key.wasPressedThisFrame || kb.numpad4Key.wasPressedThisFrame)
        stringInput += "4";
      if (kb.digit5Key.wasPressedThisFrame || kb.numpad5Key.wasPressedThisFrame)
        stringInput += "5";
      if (kb.digit6Key.wasPressedThisFrame || kb.numpad6Key.wasPressedThisFrame)
        stringInput += "6";
      if (kb.digit7Key.wasPressedThisFrame || kb.numpad7Key.wasPressedThisFrame)
        stringInput += "7";
      if (kb.digit8Key.wasPressedThisFrame || kb.numpad8Key.wasPressedThisFrame)
        stringInput += "8";
      if (kb.digit9Key.wasPressedThisFrame || kb.numpad9Key.wasPressedThisFrame)
        stringInput += "9";
      if (kb.periodKey.wasPressedThisFrame || kb.numpadPeriodKey.wasPressedThisFrame)
        stringInput += ".";
      if (kb.minusKey.wasPressedThisFrame || kb.numpadMinusKey.wasPressedThisFrame)
        stringInput += "-";
      if (kb.backspaceKey.wasPressedThisFrame && stringInput.Length > 0)
        stringInput = stringInput.Substring(0, stringInput.Length - 1);
      if (float.TryParse(stringInput, out float result))
        value = result;
    }
    public override string GetIconString()
    {
      return stringInput;
    }
  }
}

