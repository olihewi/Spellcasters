using System;
using System.Collections;
using System.Collections.Generic;
using Spellcasting.Nodes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Spellcasting.Nodes.Input
{
  public class InputNode : Node
  {
    public class Binding
    {
      public AxisControl keyboard;
      public AxisControl gamepad;
    }
    public ButtonControl bindings;
  }
}

