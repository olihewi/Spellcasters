using UnityEngine;

namespace Spellcasting.Nodes.Math.Number
{
  public class SubtractNumberNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is float f1)) return;
      float sum = f1;
      for (int i = 1; i < 5; i++)
      {
        if (inputs[i].output is float f) sum -= f;
      }
      output = sum;
    }
  }
}