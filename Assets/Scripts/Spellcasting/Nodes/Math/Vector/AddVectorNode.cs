using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
    public class AddVectorNode : Node
    {
        
        public override void Tick()
        {
            if (!(inputs[0].value is Vector3 v1)) return;
            if (!(inputs[1].value is Vector3 v2)) return;
            value = v1 + v2;
        }
    }
}
