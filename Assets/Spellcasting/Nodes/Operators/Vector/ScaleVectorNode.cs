using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
  public class ScaleVectorNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is Vector3 v)) return;
      Vector3 result = v;
      for (int i = 1; i < 5; i++)
      {
        if (inputs[i].output is float f) v *= f;
      }
      output = result;
    }
  }
}
