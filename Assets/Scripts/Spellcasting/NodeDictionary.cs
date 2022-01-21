using System;
using System.Collections.Generic;
using Spellcasting.Nodes;
using UnityEngine;

[CreateAssetMenu(menuName = "Spellcasters/Node Dictionary")]
public class NodeDictionary : ScriptableObject
{
  public enum NodeInputType
  {
    NONE,
    ANY,
    NUMBER,
    VECTOR,
    PHYSICS
  }

  [Serializable]
  public class NodeInputDesc
  {
    public NodeInputType type;
    public string name;
  }
  [Serializable]
  public class NodeType : BaseInformation
  {
    public string className;
    public List<NodeInputDesc> inputs;
    public NodeInputType outputType;
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
  public Dictionary<Type, NodeType> nodeReference;
  public Texture2D packedTextures;
  public Dictionary<Type, Rect> textureReference;
  public static NodeDictionary INSTANCE;

  public Color numberColor, vectorColor, physicsColor;

  private void OnValidate()
  {
    INSTANCE = this;
    UpdateTypes();
  }

  private void UpdateTypes()
  {
    nodeReference = new Dictionary<Type, NodeType>();
    foreach (NodeCategory category in categories)
    {
      foreach (NodeType nodeType in category.nodeTypes)
      {
        nodeType.type = Type.GetType("Spellcasting.Nodes." + nodeType.className);
        if (nodeType.type == null)
        {
          Debug.LogWarning(nodeType.name + " Node has an invalid classname!");
          continue;
        }
        nodeReference.Add(nodeType.type, nodeType);
      }
    }
  }

  public void PackTextures()
  {
    List<Texture2D> texturesToPack = new List<Texture2D>();
    foreach (KeyValuePair<Type, NodeType> nodeTypePair in nodeReference)
    {
      texturesToPack.Add(nodeTypePair.Value.icon);
    }
    int textureSize = (int) (Mathf.Sqrt(texturesToPack.Count) * 256.0F);
    packedTextures = new Texture2D(textureSize,textureSize);
    Rect[] rects = packedTextures.PackTextures(texturesToPack.ToArray(), 0, textureSize);
    textureReference = new Dictionary<Type, Rect>();
    int i = 0;
    foreach (KeyValuePair<Type, NodeType> nodeTypePair in nodeReference)
    {
      textureReference.Add(nodeTypePair.Key, rects[i]);
      i++;
    }
  }

  public Color GetTypeColor(NodeInputType _type)
  {
    switch (_type)
    {
      case NodeInputType.NONE:
        return Color.white;
      case NodeInputType.ANY:
        return Color.white;
      case NodeInputType.NUMBER:
        return numberColor;
      case NodeInputType.VECTOR:
        return vectorColor;
      case NodeInputType.PHYSICS:
        return physicsColor;
    }
    return Color.white;
  }
}