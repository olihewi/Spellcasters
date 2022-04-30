using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Math.Vector
{
  public class RaycastNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is Vector3 origin) || !(inputs[1].output is Vector3 direction)) return;
      float maxDistance = Mathf.Infinity;
      if (inputs[2] != null && inputs[2].output is float f) maxDistance = f;
      Vector3 pos = Vector3.zero;
      if (UnityEngine.Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance, RaycastSettings.Instance.layerMask))
        pos = hit.point;
      output = pos;
    }
  }
}
