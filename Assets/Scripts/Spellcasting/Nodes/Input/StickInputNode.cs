using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spellcasting.Nodes.Input
{
    public class StickInputNode : VectorNode
    {
        public enum ValidSticks
        {
            Left,
            Right
        }
        public ValidSticks stick;
        private InputAction inputAction;
        private void Start()
        {
            inputAction = stick == ValidSticks.Left ? StaticInput.input.Gameplay.PrimaryStick : StaticInput.input.Gameplay.SecondaryStick;
        }

        public override void Tick()
        {
            value = inputAction.ReadValue<Vector2>();
            value.z = value.y;
            value.y = 0;
        }
    }
}
