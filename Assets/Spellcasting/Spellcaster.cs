using System;
using System.Collections;
using System.Collections.Generic;
using Spellcasting.Nodes;
using UnityEngine;

namespace Spellcasting
{
  [RequireComponent(typeof(Rigidbody))]
  public class Spellcaster : MonoBehaviour
  {
    [HideInInspector] public Rigidbody body;

    public Dictionary<Vector2Int, Node> nodes = new Dictionary<Vector2Int, Node>();
    private Node[] tickOrder;
    
    private void Awake()
    {
      body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      if (tickOrder == null) return;
      foreach (Node node in tickOrder)
      {
        node.Tick();
      }
    }

    public void Compile()
    {
      foreach (KeyValuePair<Vector2Int, Node> nodePair in nodes)
      {
        CompileInputs(nodePair);
      }
      CompileTickOrder();
      foreach (Node node in tickOrder)
      {
        node.owner = this;
      }
    }

    // TODO: Add return value
    public void CompileInputs(KeyValuePair<Vector2Int, Node> _nodePair)
    {
      RadialNode metadata = RadialDictionary.nodeDictionary[_nodePair.Key.GetType()];
      for (int i = 0; i < metadata.inputs.Length; i++)
      {
        if (_nodePair.Value.inputs[i] != null) continue;
        NodeOutputInfo inputInfo = metadata.inputs[i];
        foreach (Vector2Int direction in Node.NeighbourDirections)
        {
          Vector2Int tile = _nodePair.Key + direction;
          if (!nodes.ContainsKey(tile)) continue;
          Node neighbour = nodes[tile];
          NodeOutputInfo outputInfo = RadialDictionary.nodeDictionary[neighbour.GetType()].output;
          if (NodeOutputInfo.Compatible(inputInfo, outputInfo))
          {
            _nodePair.Value.inputs[i] = neighbour;
            break;
          }
        }
      }
    }

    private void CompileTickOrder()
    {
      Dictionary<Node, int> depths = new Dictionary<Node, int>();
      foreach (KeyValuePair<Vector2Int, Node> nodePair in nodes)
      {
        Traverse(nodePair.Value, depths, 0);
      }
      List<Node> ticks = new List<Node>(depths.Count);
      foreach (KeyValuePair<Node, int> nodePair in depths)
      {
        ticks.Add(nodePair.Key);
      }
      ticks.Sort((_a, _b) => depths[_b].CompareTo(depths[_a]));
      tickOrder = ticks.ToArray();
    }

    private void Traverse(Node _node, Dictionary<Node, int> _depths, int _currentDepth)
    {
      if ((_depths.ContainsKey(_node) && _depths[_node] > _currentDepth) || _currentDepth > 100) return;
      foreach (Node input in _node.inputs)
      {
        Traverse(input, _depths, _currentDepth + 1);
      }
      if (!_depths.ContainsKey(_node)) _depths.Add(_node, _currentDepth);
      else _depths[_node] = _currentDepth;
    }
  }
}
