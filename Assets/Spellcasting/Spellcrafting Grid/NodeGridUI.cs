using System.Collections;
using System.Collections.Generic;
using Spellcasting.Nodes;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class NodeGridUI : MonoBehaviour
{
  public RectTransform rectTransform;
  public RawImage image;
  public Image[] inputIcons;

  public void SetNode(Node _node, RadialNode _metadata)
  {
    float hexSize = rectTransform.rect.height / 2.0F;
    gameObject.name = _metadata.name;
    image.texture = _metadata.icon;
    for (int i = 0; i < _node.inputs.Length; i++)
    {
      Node input = _node.inputs[i];
      if (input == null) continue;
      inputIcons[i].gameObject.SetActive(true);
      Vector3 thisPos = rectTransform.position;
      Vector3 difference = Spellcrafting.HexToWorld(input.gridPos, hexSize) - rectTransform.localPosition;
      inputIcons[i].rectTransform.localPosition = difference / 2.0F;
      inputIcons[i].rectTransform.rotation = Quaternion.Euler(0.0F,0.0F,Mathf.Atan2(difference.y, -difference.x) * Mathf.Deg2Rad);
      //inputIcons[i].color = NodeOutputColours.Instance.GetColour(_metadata.inputs[i].types);
    }
  }
}
