using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Radial Menu/Search")]
public class RadialSearch : RadialCategory
{
  private string query = "";
  public InputAction backspace;
  public int maxDisplayed;

  public override void OnLoaded()
  {
    Keyboard.current.onTextInput += OnType;
    backspace.performed += Backspace;
    backspace.Enable();
    query = "";
    Search();
  }
  public override void OnUnloaded()
  {
    Keyboard.current.onTextInput -= OnType;
    backspace.performed -= Backspace;
    backspace.Disable();
    query = "";
  }

  private void OnType(char _c)
  {
    if (_c >= 'A' && _c <= 'z' || _c == ' ')
    {
      query += _c;
      Search();
      Debug.Log(query);
    }
  }
  private void Backspace(InputAction.CallbackContext _context)
  {
    if (query.Length > 0)
    {
      query = query.Substring(0, query.Length - 1);
      Search();
      Debug.Log(query);
    }
  }

  private void Search()
  {
    List<RadialElement> display = new List<RadialElement>();
    foreach (string split in query.ToLower().Split(' '))
    {
      foreach (KeyValuePair<Type, RadialNode> nodePair in RadialDictionary.nodeDictionary)
      {
        foreach (string keyword in nodePair.Value.searchTags.ToLower().Split(','))
        {
          if (keyword.Contains(split))
          {
            display.Add(nodePair.Value);
            break;
          }
        }
      }
    }
    if (display.Count > maxDisplayed) display.RemoveRange(maxDisplayed, display.Count - maxDisplayed);
    elements = display.ToArray();
    RadialMenu.Instance.SetCategory(this);
  }

}
