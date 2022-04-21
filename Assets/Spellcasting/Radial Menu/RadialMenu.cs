using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
  public RadialCategory currentCategory;
  
  [Header("Controls")]
  [SerializeField] private InputAction selectInput;
  [SerializeField] private InputAction backInput;

  [Header("Prefabs")] 
  [SerializeField] private RadialElementSelector radalElementPrefab;
  [SerializeField] private RadialBackButton backButton;

  [Header("UI Elements")]
  [SerializeField] private RectTransform pointer;
  [SerializeField] private Image hoverSegment;
  [SerializeField] private TextMeshProUGUI nodeName;
  [SerializeField] private TextMeshProUGUI nodeDescription;
  [SerializeField] private TextMeshProUGUI nodeOutputLabel;
  [SerializeField] private TextMeshProUGUI nodeInputLabel;
  private List<RadialElementSelector> elements = new List<RadialElementSelector>();
  
  [Header("Settings")]
  [SerializeField] private float radius;

  private RadialElementSelector currentSelection;

  private void Awake()
  {
    SetCategory(currentCategory);
  }

  private void OnEnable()
  {
    selectInput.Enable();
    selectInput.performed -= Select;
    selectInput.performed += Select;
    backInput.Enable();
    backInput.performed -= Back;
    backInput.performed += Back;
  }

  private void OnDisable()
  {
    selectInput.performed -= Select;
    selectInput.Disable();
    backInput.performed -= Back;
    backInput.Disable();
  }

  public void SetCategory(RadialCategory _category)
  {
    if (_category == null) return;
    foreach (RadialElementSelector element in elements)
    {
      Destroy(element.gameObject);
    }
    elements.Clear();
    
    currentCategory = _category;
    
    float separation = Mathf.PI * 2.0F / (currentCategory.elements.Length + 1);
    RadialElementSelector back = Instantiate(radalElementPrefab, transform.position + new Vector3(Mathf.Sin(0) * radius, Mathf.Cos(0) * radius), Quaternion.identity, transform);
    back.SetElement(backButton);
    elements.Add(back);
    for (int i = 0; i < currentCategory.elements.Length; i++)
    {
      RadialElementSelector element = Instantiate(radalElementPrefab, transform.position + new Vector3(Mathf.Sin(separation * (i+1)) * radius, Mathf.Cos(separation * (i+1)) * radius), Quaternion.identity, transform);
      element.SetElement(currentCategory.elements[i]);
      elements.Add(element);
    }
    
    hoverSegment.fillAmount = 1.0F / elements.Count;
  }

  private void Select(InputAction.CallbackContext _ctx)
  {
    if (currentSelection == null) return;
    currentSelection.element.OnSelect(this, SpellcraftingGrid.INSTANCE);
  }
  private void Back(InputAction.CallbackContext _ctx)
  {
    SetCategory(currentCategory.parent);
  }

  private void Update()
  {
    Vector2 selectedDir = Vector2.zero;
    if (Gamepad.current != null)
      Gamepad.current.leftStick.ReadValue();
    if (selectedDir.magnitude < 0.1F && Mouse.current != null)
      selectedDir = (Mouse.current.position.ReadValue() - new Vector2(Screen.width, Screen.height) / 2.0F) / 100.0F;
    bool pointing = selectedDir.magnitude != 0.0F;
    pointer.rotation = pointing ? Quaternion.LookRotation(Vector3.forward, selectedDir) : Quaternion.identity;

    foreach (RadialElementSelector element in elements)
    {
      element.transform.localScale = Vector3.one;
    }
    
    float currentAngle = (Mathf.Atan2(selectedDir.y, -selectedDir.x) * Mathf.Rad2Deg + 270.0F + 180.0F / elements.Count) % 360.0F;
    int selection = (int) (currentAngle / (360.0F / elements.Count));
    
    currentSelection = elements[selection];
    nodeName.text = currentSelection.element.name;
    nodeDescription.text = currentSelection.element.description;
    currentSelection.element.GetTypeLabel(nodeOutputLabel);
    currentSelection.element.GetOutputLabel(nodeInputLabel);
    currentSelection.transform.localScale = Vector3.one * 1.1F;
    
    Vector3 hoverSegmentDir = Vector3.RotateTowards(currentSelection.transform.localPosition, elements[(selection + elements.Count - 1) % elements.Count].transform.localPosition,
      Vector2.Angle(currentSelection.transform.localPosition, elements[(selection + elements.Count - 1) % elements.Count].transform.localPosition) * Mathf.Deg2Rad / 2.0F, 0.0F);
    hoverSegment.transform.rotation = Quaternion.Slerp(hoverSegment.transform.rotation, Quaternion.LookRotation(Vector3.forward, hoverSegmentDir), 10 * Time.deltaTime);
  }
}
