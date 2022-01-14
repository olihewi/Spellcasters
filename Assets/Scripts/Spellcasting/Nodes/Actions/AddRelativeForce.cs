using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
    public class AddRelativeForce : AddForceNode
    {
        public override void Execute()
        {
            physicsInput.physicsValue.AddRelativeForce(vectorInput.value, ForceMode.Force);
        }
    }
}
