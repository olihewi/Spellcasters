using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
  public class ScaleVectorNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is Vector3 v)) return;
      Vector3 result = v;
      for (int i = 1; i < inputs.Length; i++)
      {
        if (inputs[i] != null && inputs[i].output is float f)
        {
          result *= f;
        }
      }
      output = result;
    }
  }
}
