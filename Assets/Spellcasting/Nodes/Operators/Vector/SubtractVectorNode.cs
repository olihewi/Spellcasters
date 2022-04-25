using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
    public class SubtractVectorNode : Node
    {
        public override void Tick()
        {
            if (!(inputs[0].output is Vector3 v1)) return;
            Vector3 sum = v1;
            for (int i = 1; i < inputs.Length; i++)
            {
                if (inputs[i] != null && inputs[i].output is Vector3 v) sum -= v;
            }
            output = sum;
        }
    }
}
