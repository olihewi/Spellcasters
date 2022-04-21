using System.Linq;
using UnityEngine;

namespace Spellcasting.Nodes.Selectors
{
    public class SelectClosestElementNode : Node
    {
        public override void Tick()
        {
            if (!(inputs[0].output is System.Array array) || !(inputs[1].output is Vector3 v)) return;
            if (inputs[0].output is Rigidbody[] rbs) output = rbs.Min(_rb => Vector3.Distance(_rb.position, v));
            else if (inputs[0].output is Vector3[] vs) output = vs.Min(_v => Vector3.Distance(_v, v));
        }
    }
}
