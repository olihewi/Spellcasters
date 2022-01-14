using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
    public class AddForceNode : Node
    {
        public override void Execute()
        {
            foreach (Node input in inputs)
            {
                if (!(input.value is Rigidbody rb)) continue;
                foreach (Node input2 in inputs)
                {
                    if (!(input2.value is Vector3 v)) continue;
                    rb.AddForce(v, ForceMode.Force);
                    break;
                }
                break;
            }
        }
    }
}
