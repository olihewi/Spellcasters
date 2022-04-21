using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Physics
{
  public class GetMassNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is Rigidbody rb)) return;
      output = rb.mass;
    }
  }
}

