using UnityEngine;

namespace Spellcasting.Nodes.Physics
{
    public class GetMassNode : NumberNode
    {
        public PhysicsNode physicsInput;

        public override CompileResponse CompileInputs(Node[] inputs)
        {
            foreach (Node input in inputs)
            {
                if (input.GetType().IsSubclassOf(typeof(PhysicsNode)))
                {
                    physicsInput = (PhysicsNode) input;
                    return CompileResponse.valid;
                }
            }
            return new CompileResponse("No Physics Input");
        }

        public override void Tick()
        {
            value = physicsInput.physicsValue.mass;
        }
    }
}
