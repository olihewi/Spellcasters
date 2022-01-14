using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
    public class AddForceNode : Node
    {
        public PhysicsNode physicsInput;
        public VectorNode vectorInput;

        public override CompileResponse CompileInputs(Node[] inputs)
        {
            bool hasPhysicsInput = false;
            bool hasVectorInput = false;
            foreach (Node input in inputs)
            {
                if (input.GetType().IsSubclassOf(typeof(PhysicsNode)))
                {
                    physicsInput = (PhysicsNode) input;
                    hasPhysicsInput = true;
                    break;
                }
            }
            foreach (Node input in inputs)
            {
                if (input.GetType().IsSubclassOf(typeof(VectorNode)))
                {
                    vectorInput = (VectorNode) input;
                    hasVectorInput = true;
                    break;
                }
            }

            if (hasPhysicsInput && hasVectorInput)
            {
                return CompileResponse.valid;
            }
            
            return new CompileResponse(hasPhysicsInput ? "No Force Input" : hasVectorInput ? "No Physics Object Input" : "No Physics Object or Force Input");
        }

        public override void Execute()
        {
            physicsInput.physicsValue.AddForce(vectorInput.value, ForceMode.Force);
        }
    }
}
