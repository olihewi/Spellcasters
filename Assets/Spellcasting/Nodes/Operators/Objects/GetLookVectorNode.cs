using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Physics
{
  public class GetLookVectorNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is Rigidbody o)) return;
      if (o.CompareTag("Player")) output = Camera.main.transform.forward;
      else output = o.transform.forward;
    }
  }
}

