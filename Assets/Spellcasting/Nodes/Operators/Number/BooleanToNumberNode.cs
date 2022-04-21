using UnityEngine;

namespace Spellcasting.Nodes.Math.Number
{
  public class BooleanToNumberNode : Node
  {
    public override void Tick()
    {
      if (!(inputs[0].output is bool b)) return;
      output = b ? 1 : 0;
    }
  }
}