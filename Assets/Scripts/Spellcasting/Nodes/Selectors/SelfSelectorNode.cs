using UnityEngine;

namespace Spellcasting.Nodes.Selectors
{
    public class SelfSelectorNode : PhysicsNode
    {
        public override void Tick()
        {
            Rigidbody self = Spellcaster.instance.player;
            physicsValue = self;
            value = self.transform;
        }
    }
}
