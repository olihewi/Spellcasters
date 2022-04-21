using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Math.Vector
{
  public class VectorNormalizeNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is Vector3 v)) return;
      output = v.normalized;
    }
  }
}
