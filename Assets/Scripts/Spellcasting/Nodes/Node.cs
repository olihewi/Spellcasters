using UnityEngine;

namespace Spellcasting.Nodes
{
    public abstract class Node
    {
        public class CompileResponse
        {
            public static CompileResponse valid = new CompileResponse();
            public CompileResponse() {}

            public CompileResponse(string _errorMessage)
            {
                isValid = false;
                errorMessage = _errorMessage;
            }
            public bool isValid = true;
            public string errorMessage = "";
        }
        public virtual CompileResponse CompileInputs(Node[] inputs) { return CompileResponse.valid; }
        public virtual void Tick() {}
        public virtual void Execute() {}
    }
}
