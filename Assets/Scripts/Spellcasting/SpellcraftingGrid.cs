using System;
using System.Collections;
using System.Collections.Generic;
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
  private List<Vector3> verts;
  private List<int> tris;

  public Transform cursor;
  private Dictionary<Vector2Int, bool> tiles = new Dictionary<Vector2Int, bool>();
  private void Awake()
  {
    INSTANCE = this;
    meshFilter = GetComponent<MeshFilter>();
  }
  private void Update()
  {
    CreateGrid();
    Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
    if (!NodeSelector.INSTANCE.gameObject.activeSelf && Physics.Raycast(mouseRay, out RaycastHit hit))
    {
      Vector2Int gridPosition = PositionToGrid(hit.point);
      cursor.position = GridToPosition(gridPosition);
      if (Mouse.current.leftButton.wasPressedThisFrame && !tiles.ContainsKey(gridPosition))
        NodeSelector.INSTANCE.Show();
      else if (Keyboard.current.deleteKey.wasPressedThisFrame && tiles.ContainsKey(gridPosition))
        tiles.Remove(gridPosition);
    }
  }

  public void AddNodeAtCursor()
  {
    tiles.Add(PositionToGrid(cursor.position),true);
  }

  private void CreateGrid()
  {
    verts = new List<Vector3>();
    tris = new List<int>();

    foreach (KeyValuePair<Vector2Int, bool> tile in tiles)
    {
      CreateCell(tile.Key);
    }
    
    Mesh mesh = new Mesh();
    mesh.name = "Hex Grid";
    mesh.vertices = verts.ToArray();
    mesh.triangles = tris.ToArray();
    mesh.RecalculateNormals();
    meshFilter.mesh = mesh;
  }

  private void CreateCell(Vector2Int _gridPos)
  {
    Vector3 position = GridToPosition(_gridPos);
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
}