using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spellcasters/Node Dictionary")]
public class NodeDictionary : ScriptableObject
{
  [Serializable]
  public class NodeType : BaseInformation
  {
    public string className;
    public Type type;
  }
  [Serializable]
  public class NodeCategory : BaseInformation
  {
    public List<NodeType> nodeTypes;
  }

  [Serializable]
  public class BaseInformation
  {
    public string name;
    public string description;
    public Texture2D icon;
  }
  
  public List<NodeCategory> categories;
  public static NodeDictionary INSTANCE;

  private void OnValidate()
  {
    INSTANCE = this;
    UpdateTypes();
  }

  private void UpdateTypes()
  {
    foreach (NodeCategory category in categories)
    {
      foreach (NodeType nodeType in category.nodeTypes)
      {
        nodeType.type = Type.GetType("Spellcasting.Nodes." + nodeType.className);
        if (nodeType.type == null)
          Debug.LogWarning(nodeType.name + " Node has an invalid classname!");
      }
    }
  }
}