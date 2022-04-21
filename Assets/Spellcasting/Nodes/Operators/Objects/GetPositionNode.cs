using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Physics
{
  public class GetPositionNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is Rigidbody rb)) return;
      output = rb.transform.position;
    }
  }
}

