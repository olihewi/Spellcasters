using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
  public class ConstructVectorNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].value is float f1)) return;
      if (!(inputs[1].value is float f2)) return;
      if (!(inputs[2].value is float f3)) return;
      value = new Vector3(f1, f2, f3);
    }
  }
}

