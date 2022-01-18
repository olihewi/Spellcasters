using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NodeSelectorElement : MonoBehaviour
{
    public RawImage image;
    public TextMeshProUGUI nodeName;
    public TextMeshProUGUI description;

    private void Update()
    {
        description.enabled = false;
    }
}
