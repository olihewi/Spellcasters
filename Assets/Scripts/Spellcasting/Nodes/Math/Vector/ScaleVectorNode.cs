using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
  public class ScaleVectorNode : Node
  {
    public override void Tick()
    {
      foreach (Node input in inputs)
      {
        if (!(input.value is Vector3 v)) continue;
        foreach (Node input2 in inputs)
        {
          if (!(input2.value is int i)) continue;
          value = v * i;
          break;
        }
        break;
      }
    }
  }
}
