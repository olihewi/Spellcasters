using System;
using System.Collections;
using System.Collections.Generic;
using Spellcasting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  public static Player Instance;
  public Camera cameraRef;
  public Spellcaster spellcaster;
  
  [Header("Controls")]
  [SerializeField] private InputAction openSpellcraftingInput;

  private void Awake()
  {
    Instance = this;
  }

  private void OnEnable()
  {
    openSpellcraftingInput.started += OpenSpellcrafting;
    openSpellcraftingInput.Enable();
  }

  private void OnDisable()
  {
    openSpellcraftingInput.started -= OpenSpellcrafting;
    openSpellcraftingInput.Disable();
  }

  private void OpenSpellcrafting(InputAction.CallbackContext _ctx)
  {
    Spellcrafting.Instance.ToggleActive();
  }
}
