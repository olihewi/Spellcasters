using UnityEngine;

namespace Spellcasting.Nodes.Selectors
{
    public class ArrayElementNode : Node
    {
        public override void Tick()
        {
            if (!(inputs[0].output is System.Array array) || !(inputs[1].output is float f)) return;
            output = array.GetValue(Mathf.FloorToInt(f));
        }
    }
}
