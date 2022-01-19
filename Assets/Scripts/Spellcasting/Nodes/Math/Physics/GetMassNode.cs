using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Physics
{
  public class GetMassNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].value is Rigidbody rb)) return;
      value = rb.mass;
    }
  }
}

