using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Spellcasting.Nodes;
using UnityEngine;

namespace Spellcasting
{
  [RequireComponent(typeof(Rigidbody))]
  public class Spellcaster : MonoBehaviour
  {
    [HideInInspector] public Rigidbody body;
    
    public float maxMana = 100.0F;
    private float currentMana = 100.0F;

    public Dictionary<Vector2Int, Node> nodes = new Dictionary<Vector2Int, Node>();
    public bool executing = true;
    private Node[] tickOrder;
    
    private void Awake()
    {
      body = GetComponent<Rigidbody>();
      currentMana = maxMana;
    }

    private void Update()
    {
      if (tickOrder == null) return;
      foreach (Node node in tickOrder)
      {
        node.Tick();
      }
    }

    public bool AddNode(Vector2Int _pos, Type _type)
    {
      if (nodes.ContainsKey(_pos)) return false;
      Node thisNode = (Node) Activator.CreateInstance(_type);
      thisNode.gridPos = _pos;
      nodes.Add(_pos, thisNode);
      CompileInputs(new KeyValuePair<Vector2Int, Node>(_pos,thisNode));
      foreach (Vector2Int dir in Node.NeighbourDirections)
      {
        if (nodes.ContainsKey(_pos + dir)) CompileInputs(new KeyValuePair<Vector2Int, Node>(_pos + dir, nodes[_pos + dir]));
      }
      return true;
    }

    public bool RemoveNode(Vector2Int _pos)
    {
      if (!nodes.ContainsKey(_pos)) return false;
      nodes.Remove(_pos);
      foreach (Vector2Int dir in Node.NeighbourDirections)
      {
        if (nodes.ContainsKey(_pos + dir)) CompileInputs(new KeyValuePair<Vector2Int, Node>(_pos + dir, nodes[_pos + dir]));
      }
      return true;
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
      Debug.Log("Successfully Compiled!");
    }

    // TODO: Add return value
    public void CompileInputs(KeyValuePair<Vector2Int, Node> _nodePair)
    {
      RadialNode metadata = RadialDictionary.nodeDictionary[_nodePair.Value.GetType()];
      for (int i = 0; i < metadata.inputs.Length; i++)
      {
        if (_nodePair.Value.inputs[i] != null)
        {
          if (!nodes.ContainsValue(_nodePair.Value.inputs[i])) _nodePair.Value.inputs[i] = null;
          else continue;
        }
        NodeOutputInfo inputInfo = metadata.inputs[i];
        foreach (Vector2Int direction in Node.NeighbourDirections)
        {
          Vector2Int tile = _nodePair.Key + direction;
          if (!nodes.ContainsKey(tile)) continue;
          Node neighbour = nodes[tile];
          NodeOutputInfo outputInfo = RadialDictionary.nodeDictionary[neighbour.GetType()].output;
          if (NodeOutputInfo.Compatible(inputInfo, outputInfo) && !neighbour.inputs.Contains(_nodePair.Value))
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
        if (input == null) continue;
        Traverse(input, _depths, _currentDepth + 1);
      }
      if (!_depths.ContainsKey(_node)) _depths.Add(_node, _currentDepth);
      else _depths[_node] = _currentDepth;
    }
  }
}
