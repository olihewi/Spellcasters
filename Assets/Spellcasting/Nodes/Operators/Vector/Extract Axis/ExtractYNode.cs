using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
  public class ExtractYNode : Node
  {
    public override void Tick()
    {
      if (inputs[0].output is Vector3 v) output = v.y;
    }
  }
}
