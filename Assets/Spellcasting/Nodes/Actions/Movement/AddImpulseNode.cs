using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
  public class AddImpulseNode : Node
  {
    public override void Execute()
    {
      if (inputs[2].output is bool b && !b) return;
      if (!(inputs[0].output is Rigidbody rb)) return;
      if (!(inputs[1].output is Vector3 v)) return;
      rb.AddForce(v, ForceMode.Impulse);
    }
  }
}

