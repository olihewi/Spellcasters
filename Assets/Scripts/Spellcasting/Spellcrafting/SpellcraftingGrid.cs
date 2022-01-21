using System;
using System.Collections;
using System.Collections.Generic;
using Spellcasting.Nodes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class SpellcraftingGrid : MonoBehaviour
{
  public static SpellcraftingGrid INSTANCE;
  [Header("Grid Settings")]
  public Vector2Int gridSize = Vector2Int.one * 16;
  public float hexagonRadius = 1.0F;
  public float outerRadius { get { return hexagonRadius / 0.866025404F; } }
  [Range(0.0F,0.25F)] public float hexagonSeparation = 1.0F;

  private MeshFilter meshFilter;
  private MeshRenderer meshRenderer;
  private List<Vector3> verts;
  private List<int> tris;
  private List<Vector2> uvs;

  public SpellcraftingCursor cursor;
  public Dictionary<Vector2Int, Node> tiles = new Dictionary<Vector2Int, Node>();
  private List<TextMeshPro> nodeIconStrings = new List<TextMeshPro>();

  public Camera mainCamera;
  public Camera spellcraftingCamera;
  public LayerMask layerMask;
  public TextMeshPro nodeIconStringPrefab;
  private void Awake()
  {
    INSTANCE = this;
    meshFilter = GetComponent<MeshFilter>();
    meshRenderer = GetComponent<MeshRenderer>();
    NodeDictionary.INSTANCE.PackTextures();
  }
  private void Update()
  {
    CreateGrid();
    Ray mouseRay = spellcraftingCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
    if (!NodeSelector.INSTANCE.gameObject.activeSelf && Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity, layerMask))
    {
      Vector2Int gridPosition = PositionToGrid(hit.point);
      bool hasNode = tiles.ContainsKey(gridPosition);
      cursor.transform.localPosition = GridToPosition(gridPosition) + Vector3.back * 0.1F;
      cursor.nodeName.text = hasNode ? NodeDictionary.INSTANCE.nodeReference[tiles[gridPosition].GetType()].name : "";
      cursor.background.gameObject.SetActive(hasNode);
      if (hasNode)
      {
        tiles[gridPosition].OnSelectedInGrid();
        foreach (Node input in tiles[gridPosition].inputs)
        {
          
        }
      }
      if (Mouse.current.rightButton.wasPressedThisFrame && !hasNode)
        NodeSelector.INSTANCE.Show();
      else if (Keyboard.current.deleteKey.wasPressedThisFrame && hasNode)
        tiles.Remove(gridPosition);
    }
  }

  public void AddNodeAtCursor(Node _node)
  {
    tiles.Add(PositionToGrid(cursor.transform.position),_node);
    Compile();
  }

  private void CreateGrid()
  {
    verts = new List<Vector3>();
    tris = new List<int>();
    uvs = new List<Vector2>();
    foreach (TextMeshPro nodeIconString in nodeIconStrings)
    {
      Destroy(nodeIconString.gameObject);
    }
    nodeIconStrings.Clear();

    foreach (KeyValuePair<Vector2Int, Node> tile in tiles)
    {
      CreateCell(tile);
    }
    
    Mesh mesh = new Mesh();
    mesh.name = "Hex Grid";
    mesh.vertices = verts.ToArray();
    mesh.triangles = tris.ToArray();
    mesh.uv = uvs.ToArray();
    mesh.RecalculateNormals();
    meshFilter.mesh = mesh;
    meshRenderer.material.mainTexture = NodeDictionary.INSTANCE.packedTextures;
  }

  private void CreateCell(KeyValuePair<Vector2Int, Node> _node)
  {
    Vector3 position = GridToPosition(_node.Key);
    int triOffset = verts.Count;
    verts.AddRange(new []
    {
      position,
      position + new Vector3(0.0F,outerRadius,0.0F),
      position + new Vector3(hexagonRadius,0.5F * outerRadius, 0.0F),
      position + new Vector3(hexagonRadius, -0.5F * outerRadius, 0.0F),
      position + new Vector3(0.0F, -outerRadius, 0.0F),
      position + new Vector3(-hexagonRadius, -0.5F * outerRadius, 0.0F),
      position + new Vector3(-hexagonRadius, 0.5F * outerRadius, 0.0F)
    });
    tris.AddRange(new []
    {
      triOffset, triOffset + 1, triOffset + 2,
      triOffset, triOffset + 2, triOffset + 3,
      triOffset, triOffset + 3, triOffset + 4,
      triOffset, triOffset + 4, triOffset + 5,
      triOffset, triOffset + 5, triOffset + 6,
      triOffset, triOffset + 6, triOffset + 1
    });
    Rect rect = NodeDictionary.INSTANCE.textureReference[_node.Value.GetType()];
    float margin = rect.height * 0.267949192F;
    uvs.AddRange(new []
    {
      rect.center,
      new Vector2(rect.center.x, rect.yMax),
      new Vector2(rect.xMax, rect.yMax - margin),
      new Vector2(rect.xMax, rect.yMin + margin),
      new Vector2(rect.center.x, rect.yMin),
      new Vector2(rect.xMin, rect.yMin + margin),
      new Vector2(rect.xMin, rect.yMax - margin) 
    });
    string nodeIconString = _node.Value.GetIconString();
    if (nodeIconString != "")
    {
      TextMeshPro thisNodeIconString = Instantiate(nodeIconStringPrefab, Vector3.zero, transform.rotation, transform);
      thisNodeIconString.transform.localPosition = position + Vector3.back * 0.1F;
      thisNodeIconString.text = nodeIconString;
      nodeIconStrings.Add(thisNodeIconString);
    }
  }

  public Vector3 GridToPosition(Vector2Int _gridPos)
  {
    Vector2 gridDims = new Vector3(
      gridSize.x * (hexagonRadius * 2.0F + hexagonSeparation),
      gridSize.y * (outerRadius * 1.5F + hexagonSeparation)
    );
    return new Vector3(
      gridDims.x * ((_gridPos.x - _gridPos.y * 0.5F) / gridSize.x),
      gridDims.y * (_gridPos.y / (float) gridSize.y),
      0.0F
    );
  }

  public Vector2Int PositionToGrid(Vector3 _position)
  {
    Vector3 pos = transform.InverseTransformPoint(_position);
    //float offset = pos.y / (outerRadius * 3.0F);
    float x = (0.577350269F * pos.x - 0.333333333F * pos.y) / outerRadius;
    float y = (0.666666666F * pos.y) / outerRadius;
    int xgrid = Mathf.RoundToInt(x);
    int ygrid = Mathf.RoundToInt(y);
    x -= xgrid;
    y -= ygrid;
    if (Mathf.Abs(x) >= Mathf.Abs(y))
      return new Vector2Int(xgrid + Mathf.RoundToInt(x + 0.5F * y) + ygrid, ygrid);
    return new Vector2Int(xgrid + ygrid + Mathf.RoundToInt(y+0.5F*x), ygrid + Mathf.RoundToInt(y + 0.5F * x));
  }

  public void Compile()
  {
    foreach (KeyValuePair<Vector2Int, Node> nodePair in tiles)
    {
      Node node = nodePair.Value;
      NodeDictionary.NodeType nodeType = NodeDictionary.INSTANCE.nodeReference[node.GetType()];
      node.inputs.Clear();
      List<Vector2Int> neighbours = new List<Vector2Int>
      {
        nodePair.Key + Vector2Int.up,
        nodePair.Key + Vector2Int.left,
        nodePair.Key + Vector2Int.one,
        nodePair.Key + Vector2Int.down,
        nodePair.Key + Vector2Int.right,
        nodePair.Key - Vector2Int.one,
      };
      foreach (NodeDictionary.NodeInputDesc desc in nodeType.inputs)
      {
        foreach (Vector2Int pos in neighbours)
        {
          if (!tiles.ContainsKey(pos)) continue;
          Node otherNode = tiles[pos];
          if (NodeDictionary.INSTANCE.nodeReference[otherNode.GetType()].outputType == desc.type || desc.type == NodeDictionary.NodeInputType.ANY)
          {
            node.inputs.Add(otherNode);
            neighbours.Remove(pos);
            break;
          }
        }
      }
    }
  }

  public void ToggleEnabled()
  {
    mainCamera.enabled = gameObject.activeSelf;
    gameObject.SetActive(!gameObject.activeSelf);
    spellcraftingCamera.enabled = gameObject.activeSelf;
  }

  public Vector2Int GetNodePosition(Node _node)
  {
    foreach (KeyValuePair<Vector2Int, Node> nodePair in tiles)
    {
      if (nodePair.Value == _node) return nodePair.Key;
    }
    return Vector2Int.zero;
  }
}