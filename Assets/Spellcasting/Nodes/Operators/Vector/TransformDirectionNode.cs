using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Math.Vector
{
  public class TransformDirectionNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is Rigidbody rb)) return;
      if (!(inputs[1].output is Vector3 v)) return;
      output = rb.transform.TransformDirection(v);
    }
  }
}
