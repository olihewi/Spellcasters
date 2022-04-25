using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Raycast Settings")]
public class RaycastSettings : ScriptableObject
{
  public static RaycastSettings Instance;
  public LayerMask layerMask;

  private void OnValidate()
  {
    Instance = this;
  }
}
