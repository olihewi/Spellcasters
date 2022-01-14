namespace Spellcasting.Nodes.Math.Vector
{
  public class ScaleVectorNode : VectorNode
  {
    public VectorNode vectorInput;
    public NumberNode numberInput;

    public override CompileResponse CompileInputs(Node[] inputs)
    {
      bool hasVectorInput = false;
      bool hasNumberInput = false;
      
      foreach (Node input in inputs)
      {
        if (input.GetType().IsSubclassOf(typeof(VectorNode)))
        {
          vectorInput = (VectorNode) input;
          hasVectorInput = true;
          break;
        }
      }
      foreach (Node input in inputs)
      {
        if (input.GetType().IsSubclassOf(typeof(NumberNode)))
        {
          numberInput = (NumberNode) input;
          hasNumberInput = true;
          break;
        }
      }
      if (hasVectorInput && hasNumberInput)
      {
        return CompileResponse.valid;
      }
            
      return new CompileResponse(hasVectorInput ? "No Number Input" : hasNumberInput ? "No Vector Input" : "No Vector or Number Input");
    }

    public override void Tick()
    {
      value = vectorInput.value * numberInput.value;
    }
  }
}
