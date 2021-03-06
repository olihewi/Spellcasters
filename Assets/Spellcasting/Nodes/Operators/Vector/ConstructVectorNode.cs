using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
  public class ConstructVectorNode : Node
  {
    public override void Tick()
    {
      Vector3 result = Vector3.zero;
      if (inputs[0] != null && inputs[0].output is float f1) result.x = f1;
      if (inputs[1] != null && inputs[1].output is float f2) result.y = f2;
      if (inputs[2] != null && inputs[2].output is float f3) result.z = f3;
      output = result;
    }
  }
}

