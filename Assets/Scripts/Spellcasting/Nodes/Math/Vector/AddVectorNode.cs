using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
    public class AddVectorNode : Node
    {
        
        public override void Tick()
        {
            Vector3 total = Vector3.zero;
            foreach (Node input in inputs)
            {
                if (input.value is Vector3 v)
                {
                    total += v;
                }
            }
            value = total;
        }
    }
}
