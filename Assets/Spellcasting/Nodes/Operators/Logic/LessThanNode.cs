using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Logic
{
    
  public class LessThanNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is float f1) || !(inputs[1].output is float f2)) return;
      output = f1 < f2;
    }
  }
}
