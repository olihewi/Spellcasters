using System;
using System.Collections;
using System.Collections.Generic;
using Spellcasting;
using Spellcasting.Nodes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Spellcrafting : MonoBehaviour
{
  public static Spellcrafting Instance;
  public Spellcaster spellcaster;
  [Header("Controls")] 
  [SerializeField] private InputAction selectInput;
  [SerializeField] private InputAction backInput;
  [SerializeField] private InputAction openRadialMenuInput;
  [SerializeField] private InputAction cursorMovementInput;

  [Header("UI Elements")] 
  [SerializeField] private RectTransform rectTransform;
  [SerializeField] private SpellcraftingCursor cursor;
  [SerializeField] private RawImage scroll;
  [SerializeField] private RectTransform scrollParent;
  [SerializeField] private GameObject crosshair;
  [Header("Prefabs")]
  [SerializeField] private NodeGridUI nodeGridPrefab;

  [Header("Settings")] 
  [SerializeField] private float hexSize = 75.0F;
  [SerializeField] private float scrollSpeed = 1.0F;
  [SerializeField] private float zoomSpeed = 1.0F;
  [SerializeField] private float selectTime = 0.25F;

  private Dictionary<Vector2Int, NodeGridUI> nodeIcons = new Dictionary<Vector2Int, NodeGridUI>();
  private Vector2Int cursorPos = Vector2Int.zero;
  private float timeLastSelected = 0.0F;
  private bool alternatingRot;

  private void Awake()
  {
    Instance = this;
    ToggleActive();
  }
  private void OnEnable()
  {
    BindControls();
  }
  private void OnDisable()
  {
    UnbindControls();
  }

  public void BindControls()
  {
    openRadialMenuInput.started += OnRadialInput;
    openRadialMenuInput.Enable();
    selectInput.started += OnSelectInput;
    selectInput.Enable();
    backInput.started += OnBackInput;
    backInput.Enable();
    cursorMovementInput.Enable();
  }

  public void UnbindControls()
  {
    selectInput.started -= OnSelectInput;
    selectInput.Disable();
    backInput.started -= OnBackInput;
    backInput.Disable();
    openRadialMenuInput.started -= OnRadialInput;
    openRadialMenuInput.Disable();
    cursorMovementInput.Disable();
  }

  public void ToggleActive()
  {
    gameObject.SetActive(!gameObject.activeSelf);
    enabled = gameObject.activeSelf;
    spellcaster.executing = !gameObject.activeSelf;
    Player.Instance.spellcaster.executing = !gameObject.activeSelf;
    RadialMenu.Instance.Close();
    crosshair.SetActive(!gameObject.activeSelf);
    if (!gameObject.activeSelf) spellcaster.Compile();
  }
  private void OnSelectInput(InputAction.CallbackContext _context)
  {
    RadialMenu.Instance.Select();
  }
  private void OnBackInput(InputAction.CallbackContext _context)
  {
    RadialMenu.Instance.Back();
  }

  private void OnRadialInput(InputAction.CallbackContext _context)
  {
    if (!spellcaster.RemoveNode(cursorPos)) RadialMenu.Instance.Open();
    UpdateGrid();
  }

  private void Update()
  {
    if (RadialMenu.Instance.gameObject.activeSelf) return;
    // Cursor movement
    Vector2 cursorMovement = cursorMovementInput.ReadValue<Vector2>();
    if (Time.time - timeLastSelected >= selectTime && cursorMovement.magnitude > 0.25F)
    { 
      cursorMovement.x += alternatingRot ? 0.2F : -0.2F;
      cursorPos = WorldToHex(HexToWorld(cursorPos, hexSize) + new Vector3(cursorMovement.x,cursorMovement.y,0.0F).normalized * (hexSize * 1.5F), hexSize);
      alternatingRot = !alternatingRot;
      timeLastSelected = Time.time;
    }
    if (Mouse.current != null && Mouse.current.delta.ReadValue().sqrMagnitude > 0.1F)
    {
      Vector2 mousePos = Mouse.current.position.ReadValue() - new Vector2(Screen.width / 2.0F, Screen.height / 2.0F);
      cursorPos = WorldToHex(mousePos, hexSize);
    }
    cursor.rectTransform.localPosition = HexToWorld(cursorPos, hexSize);
    
    if (spellcaster.nodes.ContainsKey(cursorPos))
    {
      cursor.label.text = RadialDictionary.nodeDictionary[spellcaster.nodes[cursorPos].GetType()].name;
      cursor.label.transform.parent.gameObject.SetActive(true);
    }
    else cursor.label.transform.parent.gameObject.SetActive(false);
    //Scroll();
    //Zoom();
  }

  public void PlaceNodeAtCursor(Type _type)
  {
    if (spellcaster.AddNode(cursorPos, _type)) UpdateGrid();
  }

  private void UpdateGrid()
  {
    foreach (KeyValuePair<Vector2Int, NodeGridUI> iconPair in nodeIcons)
    {
      Destroy(iconPair.Value.gameObject);
    }
    nodeIcons = new Dictionary<Vector2Int, NodeGridUI>(spellcaster.nodes.Count);
    foreach (KeyValuePair<Vector2Int, Node> nodePair in spellcaster.nodes)
    {
      RadialNode metadata = RadialDictionary.nodeDictionary[nodePair.Value.GetType()];
      NodeGridUI icon = Instantiate(nodeGridPrefab, scrollParent);
      icon.rectTransform.localPosition = HexToWorld(nodePair.Key, icon.rectTransform.rect.height / 2.0F);
      icon.SetNode(nodePair.Value,metadata);
      nodeIcons.Add(nodePair.Key, icon);
    }
  }

  public static Vector3 HexToWorld(Vector2Int _axialCoords, float _hexSize)
  {
    return new Vector3(
      _hexSize * (Mathf.Sqrt(3.0F) * _axialCoords.x - Mathf.Sqrt(3.0F) / 2.0F * _axialCoords.y),
      _hexSize * (3.0F / 2.0F * _axialCoords.y),
      0.0F);
  }

  public static Vector2Int WorldToHex(Vector3 _worldCoords, float _hexSize)
  {
    return RoundToHex(new Vector2(
      (Mathf.Sqrt(3.0F) / 3.0F * _worldCoords.x + 1.0F / 3.0F * _worldCoords.y) / _hexSize,
      (2.0F / 3.0F * _worldCoords.y) / _hexSize));
  }

  public static Vector2Int RoundToHex(Vector2 _axialCoords)
  {
    Vector2 otherAxial = new Vector2(_axialCoords.x, -_axialCoords.x -_axialCoords.y);
    Vector2Int rounded = Vector2Int.RoundToInt(otherAxial);
    Vector2 r = otherAxial - rounded;
    Vector2Int d = new Vector2Int(
      Mathf.RoundToInt(r.x + 0.5F * r.y) * (r.x * r.x >=  r.y * r.y ? 1 : 0),
      Mathf.RoundToInt(r.y + 0.5F * r.x) * (r.x * r.x < r.y * r.y ? 1 : 0));
    Vector2Int o = rounded + d;
    return new Vector2Int(o.x,-o.x-o.y);
  }

  private void Scroll()
  {
    Vector2 scrollInput = Vector2.zero;
    if (Mouse.current != null && Mouse.current.middleButton.isPressed) scrollInput -= Mouse.current.delta.ReadValue();
    if (Gamepad.current != null) scrollInput -= Gamepad.current.rightStick.ReadValue() * (scrollSpeed * Time.deltaTime);
    if (Keyboard.current != null) scrollInput += new Vector2(
      Keyboard.current.rightArrowKey.ReadValue() - Keyboard.current.leftArrowKey.ReadValue(),
      Keyboard.current.upArrowKey.ReadValue() - Keyboard.current.downArrowKey.ReadValue()) * (scrollSpeed * Time.deltaTime);
    
    scrollInput.Scale(new Vector2(
      scroll.uvRect.width / scroll.rectTransform.rect.width, 
      scroll.uvRect.height / scroll.rectTransform.rect.height));
    scroll.uvRect = new Rect(scroll.uvRect.min + scrollInput, scroll.uvRect.size);
  }

  private IEnumerator I_GotoTile(Vector2Int _tile, float _time)
  {
    float t = 0.0F;
    while (t <= _time)
    {
      
      t += Time.deltaTime;
      yield return null;
    }
  }

  private void Zoom()
  {
    float zoomInput = 0.0F;
    if (Mouse.current != null) zoomInput += Mouse.current.scroll.y.ReadValue() / 100.0F;
    if (Gamepad.current != null) zoomInput += (Gamepad.current.rightTrigger.ReadValue() - Gamepad.current.leftTrigger.ReadValue()) * Time.deltaTime;
    
    Vector2 uvCentre = scroll.uvRect.center;
    Vector2 uvSize = scroll.uvRect.size;
    uvSize *= 1.0F - (zoomInput * zoomSpeed);
    scroll.uvRect = new Rect(uvCentre - uvSize / 2.0F, uvSize);
  }
}
