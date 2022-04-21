using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Constants
{
  public class ConstantPiNode : Node
  {
    public ConstantPiNode()
    {
      output = Mathf.PI;
    }
  }
}

