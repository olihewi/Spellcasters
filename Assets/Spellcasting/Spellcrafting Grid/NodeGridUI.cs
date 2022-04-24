using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeGridUI : MonoBehaviour
{
  public RectTransform rectTransform;
  public RawImage image;
  public Image[] inputIcons;

  public void SetNode(RadialNode _node)
  {
    gameObject.name = _node.name;
    image.texture = _node.icon;
  }
}
