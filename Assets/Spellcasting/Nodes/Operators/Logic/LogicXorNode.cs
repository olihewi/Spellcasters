using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Logic
{
  public class LogicXorNode : Node
  {
    public override void Tick()
    {
      int count = 0;
      int tally = 0;
      for (int i = 0; i < 5; i++)
      {
        if (!(inputs[i].output is bool b)) continue;
        count++;
        if (b) tally++;
      }
      output = tally > 0 && tally < count;
    }
  }
}