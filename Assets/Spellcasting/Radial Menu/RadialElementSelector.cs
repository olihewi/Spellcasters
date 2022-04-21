using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialElementSelector : MonoBehaviour
{
  public RadialElement element;
  [SerializeField] private RawImage image;

  public void SetElement(RadialElement _element)
  {
    element = _element;
    image.texture = _element.icon;
  }
}
