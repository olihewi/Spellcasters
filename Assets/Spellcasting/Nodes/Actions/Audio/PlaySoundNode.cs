using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
    public class PlaySoundNode : Node
    {
        public override void Tick()
        {
            if (inputs[4] != null && inputs[4].output is bool b && !b) return;
            if (!(inputs[0].output is Vector3 pos) || !(inputs[1].output is float volume) || 
                !(inputs[2].output is float pitch) || !(inputs[3].output is float instrument)) return;
            PlaySoundManager.Instance.PlaySound(pos, volume, pitch, instrument);
        }
    }
}
