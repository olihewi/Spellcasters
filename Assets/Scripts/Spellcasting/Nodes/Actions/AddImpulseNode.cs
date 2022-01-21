using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
  public class AddImpulseNode : Node
  {
    public override void Execute()
    {
      if (!(inputs[0].value is Rigidbody rb)) return;
      if (!(inputs[1].value is Vector3 v)) return;
      rb.AddForce(v, ForceMode.Impulse);
    }
  }
}

