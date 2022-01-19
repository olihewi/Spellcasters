using UnityEngine;
using System.Collections.Generic;

namespace Spellcasting.Nodes
{
  public abstract class Node
  {
    public class CompileResponse
    {
      public static CompileResponse valid = new CompileResponse();
      public CompileResponse() { }

      public CompileResponse(string _errorMessage)
      {
        isValid = false;
        errorMessage = _errorMessage;
      }
      public bool isValid = true;
      public string errorMessage = "";
    }

    public virtual void Tick() { }
    public virtual void Execute() { }
    public virtual void OnSelectedInGrid() { }

    public System.Object value;
    public List<Node> inputs = new List<Node>();
  }
}
