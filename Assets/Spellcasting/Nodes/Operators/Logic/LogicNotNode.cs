using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Logic
{
  public class LogicNotNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is bool b)) return;
      output = !b;
    }
  }
}