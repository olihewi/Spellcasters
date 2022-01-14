using UnityEngine.UI;

namespace Spellcasting.Nodes.Debug
{
    public class DebugNode : Node
    {
        public override void Execute()
        {
            UnityEngine.Debug.Log(inputs[0].value);
        }
    }
}
