using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Math.Vector
{
    public class AddVectorNode : VectorNode
    {
        public List<VectorNode> vectorInputs;

        public override CompileResponse CompileInputs(Node[] inputs)
        {
            vectorInputs.Clear();
            foreach (Node input in inputs)
            {
                if (input.GetType().IsSubclassOf(typeof(VectorNode)))
                {
                    vectorInputs.Add((VectorNode) input);
                }
            }

            return vectorInputs.Count >= 1 ? CompileResponse.valid : new CompileResponse("No Vector Inputs");
        }
        
        public override void Tick()
        {
            value = Vector3.zero;
            foreach (VectorNode input in vectorInputs)
            {
                value += input.value;
            }
        }
    }
}
