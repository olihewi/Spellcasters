using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

[CreateAssetMenu(menuName = "Radial Menu/Category")]
public class RadialCategory : RadialElement
{
  public RadialElement[] elements;

  private void OnValidate()
  {
    #if UNITY_EDITOR
    string assetPath = AssetDatabase.GetAssetPath(this);
    assetPath = assetPath.Substring(0,assetPath.LastIndexOf('.'));

    if (!Directory.Exists(assetPath)) return;
    
    string[] guids = AssetDatabase.FindAssets(null, new[] {assetPath});
    List<RadialElement> newRadialElements = new List<RadialElement>();
    foreach (string guid in guids)
    {
      string thisAssetPath = AssetDatabase.GUIDToAssetPath(guid);
      if (thisAssetPath.Substring(0, thisAssetPath.LastIndexOf('/')) != assetPath) continue;
      RadialElement r = (RadialElement) AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(RadialElement));
      if (r != null) newRadialElements.Add(r);
    }
    List<RadialElement> oldRadialElements = elements.ToList();
    foreach (RadialElement e in newRadialElements)
    {
      if (!oldRadialElements.Contains(e)) oldRadialElements.Add(e);
    }
    List<RadialElement> toRemove = new List<RadialElement>();
    foreach (RadialElement e in oldRadialElements)
    {
      if (!newRadialElements.Contains(e)) toRemove.Add(e);
    }
    foreach (RadialElement e in toRemove)
    {
      oldRadialElements.Remove(e);
    }
    elements = oldRadialElements.ToArray();
    
#endif
    foreach (RadialElement element in elements)
    {
      if (element == null) continue;
      element.parent = this;
    }
  }

  public override void OnSelect(RadialMenu _menu, SpellcraftingGrid _grid)
  {
    _menu.SetCategory(this);
  }

  public override void GetTypeLabel(TextMeshProUGUI _label)
  {
    _label.text = "Category";
    _label.color = Color.white;
  }

  public override void GetOutputLabel(TextMeshProUGUI _label)
  {
    _label.text = "";
  }
}
