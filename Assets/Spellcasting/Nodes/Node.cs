using UnityEngine;
using System.Collections.Generic;

namespace Spellcasting.Nodes
{
  public abstract class Node : MonoBehaviour
  {
    public System.Object output;
    public List<Node> inputs = new List<Node>();
    public virtual void Tick() { }
    public virtual void Execute() { }
    public virtual void OnSelectedInGrid() { }
    public virtual string GetIconString() { return ""; }

  }
}
