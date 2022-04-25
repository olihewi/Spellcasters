using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UIElements;

namespace Spellcasting.Nodes
{
  public abstract class Node
  {
    public Spellcaster owner;
    public System.Object output;
    public Node[] inputs = new Node[6];
    public Vector2Int gridPos;
    public bool compiled = false;
    public RadialNode metadata => RadialDictionary.nodeDictionary[GetType()];
    public virtual void Tick() { }
    public virtual void OnSelectedInGrid() { }
    public virtual string GetIconString() { return ""; }

    public static Vector2Int[] NeighbourDirections = 
    {
      Vector2Int.left, Vector2Int.up, Vector2Int.one, Vector2Int.right, Vector2Int.down, -Vector2Int.one
    };
  }
}
