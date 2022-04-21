using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Logic
{
  public class LogicOrNode : Node
  {
    public override void Tick()
    {
      output = false;
      for (int i = 0; i < 5; i++)
      {
        if (!(inputs[i].output is bool b)) continue;
        if (!b) continue;
        output = true;
        return;
      }
    }
  }
}