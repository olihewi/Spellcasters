using UnityEngine;

namespace Spellcasting.Nodes.Selectors
{
    public class SelfSelectorNode : Node
    {
        public override void Tick()
        {
            output = owner;
        }
    }
}
