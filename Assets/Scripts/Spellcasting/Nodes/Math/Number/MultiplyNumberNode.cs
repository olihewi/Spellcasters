using UnityEngine;

namespace Spellcasting.Nodes.Math.Number
{
  public class MultiplyNumberNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].value is float f1)) return;
      if (!(inputs[1].value is float f2)) return;
      value = f1 * f2;
    }
  }
}