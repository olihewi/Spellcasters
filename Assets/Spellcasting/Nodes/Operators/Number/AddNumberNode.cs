using UnityEngine;

namespace Spellcasting.Nodes.Math.Number
{
  public class AddNumberNode : Node
  {
    public override void Tick()
    {
      float sum = 0.0F;
      foreach (Node node in inputs)
      {
        if (node.output is float f) sum += f;
      }
      output = sum;
    }
  }
}