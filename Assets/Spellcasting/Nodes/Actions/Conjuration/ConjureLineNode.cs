using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Actions.Conjuration
{
  public class ConjureLineNode : Node
  {
    public override void Tick()
    {
      if (inputs[2] != null && inputs[2].output is bool b && b) return;
      if (!(inputs[0].output is Vector3 start) || !(inputs[1].output is Vector3 end)) return;
      ConjureLineManager.Instance.ConjureLine(start,end);
    }
  }
}