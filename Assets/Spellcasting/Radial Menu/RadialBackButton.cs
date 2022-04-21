using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Radial Menu/Back Button")]
public class RadialBackButton : RadialElement
{
    public override void OnSelect(RadialMenu _menu, SpellcraftingGrid _grid)
    {
        _menu.SetCategory(_menu.currentCategory.parent);
    }

    public override void GetTypeLabel(TextMeshProUGUI _label)
    {
        _label.text = "";
    }

    public override void GetOutputLabel(TextMeshProUGUI _label)
    {
        _label.text = "";
    }
}
