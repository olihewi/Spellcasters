using UnityEngine;

namespace Spellcasting.Nodes.Math.Number
{
  public class ExponentiateNumberNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is float f1) || !(inputs[1].output is float f2)) return;
      output = Mathf.Pow(f1,f2);
    }
  }
}