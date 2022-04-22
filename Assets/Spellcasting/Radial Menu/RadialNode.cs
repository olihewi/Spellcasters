using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

[Flags]
public enum NodeOutputTypes
{
  Number = 1<<0,
  Vector = 1<<1,
  Object = 1<<2,
  Boolean = 1<<3,
  
  Array = 1<<9,
  Optional = 1<<10
}

[Serializable]
public struct NodeOutputInfo
{
  public NodeOutputTypes types;
  public string label;
}

[CreateAssetMenu(menuName = "Radial Menu/Node")]
public class RadialNode : RadialElement
{
  public Type type;
  public NodeOutputInfo[] inputs;
  public NodeOutputInfo output;
  public string searchTags = "";
  [HideInInspector] public string className = "Spellcasting.Nodes.";
  [NonSerialized] public int useCount = 0;
  
  public override void OnSelect(RadialMenu _menu, SpellcraftingGrid _grid)
  {
    useCount++;
  }

  public string OutputInfoToString(NodeOutputInfo _type)
  {
    string label = _type.types.ToString();
    label = label.Replace(", Array", " []");
    label = label.Replace("0", "Action");
    label = label.Replace(", Optional", " (Optional)");
    label = label.Replace("Number, Vector, Object, Boolean", "Any");
    label = label.Replace(",", " or");
    return label;
  }
  public string InputInfoToString()
  {
    string label = "";
    foreach (NodeOutputInfo info in inputs)
    {
      label += info.label + ": " + OutputInfoToString(info) + '\n';
    }
    return label;
  }
  public override void GetTypeLabel(TextMeshProUGUI _label)
  {
    _label.text = OutputInfoToString(output);
  }

  public override void GetOutputLabel(TextMeshProUGUI _label)
  {
    _label.text = InputInfoToString();
  }

  public bool RegisterType()
  {
    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
    {
      type = a.GetType(className);
      if (type != null) return true;
    }
    return false;
  }
}
