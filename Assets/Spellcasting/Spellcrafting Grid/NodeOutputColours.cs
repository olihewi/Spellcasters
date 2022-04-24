using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Node Output Colours")]
public class NodeOutputColours : ScriptableObject
{
  public static NodeOutputColours Instance;
  public Color number;
  public Color vector;
  public Color physics;
  public Color boolean;

  private void OnValidate()
  {
    Instance = this;
  }

  public Color GetColour(NodeOutputTypes _types)
  {
    if ((int) (_types & (NodeOutputTypes.Boolean | NodeOutputTypes.Number | NodeOutputTypes.Vector | NodeOutputTypes.Object )) == 0) return Color.white;
    if (_types.HasFlag(NodeOutputTypes.Number)) return number;
    if (_types.HasFlag(NodeOutputTypes.Vector)) return vector;
    if (_types.HasFlag(NodeOutputTypes.Object)) return physics;
    if (_types.HasFlag(NodeOutputTypes.Boolean)) return boolean;
    return Color.black;
  }
}
