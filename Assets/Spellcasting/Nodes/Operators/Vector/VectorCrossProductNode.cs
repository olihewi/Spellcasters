using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Math.Vector
{
  public class VectorCrossProductNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is Vector3 v1) || !(inputs[1].output is Vector3 v2)) return;
      output = Vector3.Cross(v1,v2);
    }
  }
}
