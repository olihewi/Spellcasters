using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Math.Vector
{
  public class TransformDirectionNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].value is Rigidbody rb)) return;
      if (!(inputs[1].value is Vector3 v)) return;
      value = rb.transform.TransformDirection(v);
    }
  }
}
