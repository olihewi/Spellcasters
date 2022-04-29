using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
  public class ExtractZNode : Node
  {
    public override void Tick()
    {
      if (inputs[0].output is Vector3 v) output = v.z;
    }
  }
}
