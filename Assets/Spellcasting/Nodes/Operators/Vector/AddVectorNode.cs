using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
    public class AddVectorNode : Node
    {
        public override void Tick()
        {
            Vector3 sum = Vector3.zero;
            for (int i = 0; i < 5; i++)
            {
                if (inputs[i].output is Vector3 v) sum += v;
            }
            output = sum;
        }
    }
}
