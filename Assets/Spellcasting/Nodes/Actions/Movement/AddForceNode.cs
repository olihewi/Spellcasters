using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
    public class AddForceNode : Node
    {
        public override void Tick()
        {
            if (inputs[2] != null && inputs[2].output is bool b && !b) return;
            if (!(inputs[0].output is Rigidbody rb)) return;
            if (!(inputs[1].output is Vector3 v)) return;
            rb.AddForce(v * owner.UseMana(v.magnitude * Time.deltaTime), ForceMode.Force);
        }
    }
}
