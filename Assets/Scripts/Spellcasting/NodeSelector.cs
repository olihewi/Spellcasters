using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NodeSelector : MonoBehaviour
{
  public static NodeSelector INSTANCE;
  public SpellcraftingGrid spellcraftingGrid;
  public float radius = 2.5F;
  public NodeSelectorElement selectionPrefab;

  private NodeDictionary.NodeCategory currentCategory;
  private List<NodeSelectorElement> currentSelections = new List<NodeSelectorElement>();

  private int selection = 0;

  private void Awake()
  {
    INSTANCE = this;
    gameObject.SetActive(false);
  }

  public void Show()
  {
    gameObject.SetActive(true);
    foreach (NodeSelectorElement thisSelection in currentSelections)
    {
      Destroy(thisSelection.gameObject);
    }
    currentSelections.Clear();

    NodeDictionary nodes = NodeDictionary.INSTANCE;
    if (currentCategory == null)
    {
      float separation = Mathf.PI * 2.0F / nodes.categories.Count;
      for (int i = 0; i < nodes.categories.Count; i++)
      {
        NodeDictionary.NodeCategory category = nodes.categories[i];
        NodeSelectorElement thisSelection = Instantiate(selectionPrefab, new Vector3(Mathf.Sin(separation * i) * radius, Mathf.Cos(separation * i) * radius), Quaternion.identity, transform);
        thisSelection.name.text = category.name;
        thisSelection.description.text = category.description;
        thisSelection.image.texture = category.icon;
        currentSelections.Add(thisSelection);
      }
    }
    else
    {
      float separation = Mathf.PI * 2.0F / currentCategory.nodeTypes.Count;
      for (int i = 0; i < currentCategory.nodeTypes.Count; i++)
      {
        NodeDictionary.NodeType nodeType = currentCategory.nodeTypes[i];
        NodeSelectorElement thisSelection = Instantiate(selectionPrefab, new Vector3(Mathf.Sin(separation * i) * radius, Mathf.Cos(separation * i) * radius), Quaternion.identity, transform);
        thisSelection.name.text = nodeType.name;
        thisSelection.description.text = nodeType.description;
        thisSelection.image.texture = nodeType.icon;
        currentSelections.Add(thisSelection);
      }
    }
    
  }

  private void Update()
  {
    Vector2 mousePosition = Mouse.current.position.ReadValue();
    mousePosition.x -= Screen.width / 2.0F;
    mousePosition.y -= Screen.height / 2.0F;
    if (mousePosition.magnitude > 10.0F)
    {
      float currentAngle = (Mathf.Atan2(mousePosition.y, -mousePosition.x) * Mathf.Rad2Deg + 270.0F + 180.0F / currentSelections.Count) % 360.0F;
      selection = (int) (currentAngle / (360.0F / currentSelections.Count));
    }

    foreach (NodeSelectorElement selector in currentSelections)
    {
      selector.transform.localScale = Vector3.one;
    }
    currentSelections[selection].transform.localScale *= 1.25F;
    
    if (Mouse.current.rightButton.wasPressedThisFrame)
    {
      if (currentCategory == null)
      {
        gameObject.SetActive(false);
      }
      else
      {
        currentCategory = null;
        Show();
      }
    }

    if (Mouse.current.leftButton.wasPressedThisFrame)
    {
      if (currentCategory == null && NodeDictionary.INSTANCE.categories[selection].nodeTypes.Count > 0)
      {
        currentCategory = NodeDictionary.INSTANCE.categories[selection];
        Show();
      }
      else
      {
        SpellcraftingGrid.INSTANCE.AddNodeAtCursor();
        currentCategory = null;
        gameObject.SetActive(false);
      }
    }
  }
}