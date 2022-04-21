using UnityEngine;

namespace Spellcasting.Nodes.Math.Number
{
  public class AddNumberNode : Node
  {
    public override void Tick()
    {
      float sum = 0.0F;
      for (int i = 0; i < 5; i++)
      {
        if (inputs[i].output is float f) sum += f;
      }
      output = sum;
    }
  }
}