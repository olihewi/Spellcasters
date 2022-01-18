using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
  public class ScaleVectorNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].value is Vector3 v)) return;
      if (!(inputs[1].value is float f)) return;
      value = v * f;
    }
  }
}
