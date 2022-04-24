using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UIElements;

namespace Spellcasting.Nodes
{
  public abstract class Node
  {
    public Spellcaster owner;
    public System.Object output;
    public List<Node> inputs = new List<Node>();
    public virtual void Tick() { }
    public virtual void OnSelectedInGrid() { }
    public virtual string GetIconString() { return ""; }

    public static Vector2Int[] NeighbourDirections = 
    {
      Vector2Int.left, Vector2Int.up, Vector2Int.one, Vector2Int.right, Vector2Int.down, -Vector2Int.one
    };
  }
}
