using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
    public class PlaySoundNode : Node
    {
        public override void Tick()
        {
            if (inputs[2].output is bool b && !b) return;
            if (!(inputs[0].output is float f1) || !(inputs[1].output is float f2)) return;
            // Needs sound system
        }
    }
}
