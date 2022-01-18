using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
    public class AddForceNode : Node
    {
        public override void Execute()
        {
            if (!(inputs[0].value is Rigidbody rb)) return;
            if (!(inputs[1].value is Vector3 v)) return;
            rb.AddForce(v, ForceMode.Force);
        }
    }
}
