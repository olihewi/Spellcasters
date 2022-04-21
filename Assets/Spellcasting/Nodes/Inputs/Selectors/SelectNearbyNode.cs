using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Selectors
{
    public class SelectNearbyNode : Node
    {
        public override void Tick()
        {
            if (!(inputs[0].output is Vector3 v) || !(inputs[1].output is float f)) return;
            Collider[] colliders = Physics.OverlapSphere(v, f);
            List<Rigidbody> objects = new List<Rigidbody>();
            foreach (Collider collider in colliders)
            {
                if (collider.attachedRigidbody == null) continue;
                objects.Add(collider.attachedRigidbody);
            }
            output = objects.ToArray();
        }
    }
}
