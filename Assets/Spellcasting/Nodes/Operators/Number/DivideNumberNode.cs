using UnityEngine;

namespace Spellcasting.Nodes.Math.Number
{
  public class DivideNumberNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is float f1) || !(inputs[1].output is float f2)) return;
      output = f1 / f2;
    }
  }
}