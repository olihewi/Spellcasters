using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StaticInput : MonoBehaviour
{
  public static MasterInput input;

  private void OnEnable()
  {
    input = new MasterInput();
    input.Enable();
   
  }
  private void OnDisable()
  {
    input.Disable();
  }
}
