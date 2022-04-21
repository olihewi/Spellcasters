using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class RadialElement : ScriptableObject
{
  [HideInInspector] public RadialCategory parent;
  public Texture2D icon;
  public string description;

  public abstract void OnSelect(RadialMenu _menu, SpellcraftingGrid _grid);
  public abstract void GetTypeLabel(TextMeshProUGUI _label);
  public abstract void GetOutputLabel(TextMeshProUGUI _label);
}
