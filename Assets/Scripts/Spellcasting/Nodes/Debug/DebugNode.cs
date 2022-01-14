using UnityEngine.UI;

namespace Spellcasting.Nodes.Debug
{
    public class DebugNode : Node
    {
        public Text debugText;
        public VectorNode vectorInput;
        public override CompileResponse CompileInputs(Node[] inputs)
        {
            foreach (Node input in inputs)
            {
                if (input.GetType().IsSubclassOf(typeof(VectorNode)))
                {
                    vectorInput = (VectorNode) input;
                }
            }
            return CompileResponse.valid;
        }

        public override void Execute()
        {
            debugText.text = vectorInput.value.ToString();
        }
    }
}
