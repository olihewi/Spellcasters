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
    List<RadialNode> display = new List<RadialNode>();

    string[] split = query.ToLower().Split(' ');
    foreach (KeyValuePair<Type, RadialNode> nodePair in RadialDictionary.nodeDictionary)
    {
      bool conditionsMet = true;
      string keywords = nodePair.Value.searchTags.ToLower();
      foreach (string word in split)
      {
        if (!keywords.Contains(word)) conditionsMet = false;
        else if (word.Length > 0) keywords = keywords.Replace(word, "");
      }
      if (conditionsMet) display.Add(nodePair.Value);
    }


    display.Sort((a, b) => a.useCount.CompareTo(b.useCount));
    if (display.Count > maxDisplayed) display.RemoveRange(maxDisplayed, display.Count - maxDisplayed);
    elements = new RadialElement[display.Count > maxDisplayed ? maxDisplayed : display.Count];
    for (int j = 0; j < elements.Length; j++)
    {
      elements[j] = display[j];
    }
    RadialMenu.Instance.SetCategory(this);
  }

}
