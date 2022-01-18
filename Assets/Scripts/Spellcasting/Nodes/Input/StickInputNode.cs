using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
    public class StickInputNode : Node
    {

        public override void Tick()
        {
            Vector3 v = StaticInput.input.Gameplay.PrimaryStick.ReadValue<Vector2>();
            v.z = v.y;
            v.y = 0.0F;
            value = v;
        }
    }
}
