using System;
using System.Collections;
using System.Collections.Generic;
using Spellcasting.Nodes;
using UnityEngine;

[CreateAssetMenu(menuName = "Radial Menu/Dictionary")]
public class RadialDictionary : RadialCategory
{
  public static Dictionary<Type, RadialNode> nodeDictionary = new Dictionary<Type, RadialNode>();
  public override void OnRegistered()
  {
    nodeDictionary = new Dictionary<Type, RadialNode>();
    AddCategory(this);
    Debug.Log(nodeDictionary.Count + " nodes registered!");
  }

  private void AddCategory(RadialCategory _category)
  {
    foreach (RadialElement element in _category.elements)
    {
      if (element is RadialCategory category && category != _category && !(element is RadialSearch)) 
        AddCategory(category);
      else if (element is RadialNode node && node.RegisterType() && !nodeDictionary.ContainsKey(node.type))
        nodeDictionary.Add(node.type, node);
    }
  }
}
