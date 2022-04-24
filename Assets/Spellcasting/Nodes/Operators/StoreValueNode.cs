using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes
{
  public class StoreValueNode : Node
  {
    public override void Tick()
    {
      if (inputs[1].output is bool b && b) output = inputs[0].output;
    }
  }

}