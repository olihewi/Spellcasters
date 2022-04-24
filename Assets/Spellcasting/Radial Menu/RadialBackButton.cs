using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Radial Menu/Back Button")]
public class RadialBackButton : RadialElement
{
    public override void OnSelect()
    {
        RadialMenu.Instance.SetCategory(RadialMenu.Instance.currentCategory.parent);
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
