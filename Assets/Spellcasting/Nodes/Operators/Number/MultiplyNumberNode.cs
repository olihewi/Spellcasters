using UnityEngine;

namespace Spellcasting.Nodes.Math.Number
{
  public class MultiplyNumberNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is float f1) || !(inputs[1].output is float f2)) return;
      float sum = f1 * f2;
      for (int i = 2; i < 5; i++)
      {
        if (inputs[i].output is float f) sum *= f;
      }
      output = f1 * f2;
    }
  }
}