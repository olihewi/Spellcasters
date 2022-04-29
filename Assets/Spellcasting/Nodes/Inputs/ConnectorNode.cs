using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Input
{
  public class ConnectorNode : Node
  {
    public override void Tick()
    {
      output = inputs[0].output;
    }
  }
}