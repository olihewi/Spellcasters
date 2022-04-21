using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Spellcrafting : MonoBehaviour
{
  [Header("Controls")]
  [SerializeField] private InputAction selectInput;
  [SerializeField] private InputAction addNodeInput;
  [Header("UI Elements")] 
  [SerializeField] private Image cursor;
  [SerializeField] private RawImage scroll;
  [Header("Settings")]
  [SerializeField] private float scrollSpeed = 1.0F;
  [SerializeField] private float zoomSpeed = 1.0F;

  private Vector2Int PositionToGrid(Vector2 _localPos)
  {
    float outerRadius = 1;
    float x = (0.577350269F * _localPos.x - 0.333333333F * _localPos.y) / outerRadius;
    float y = (0.666666666F * _localPos.y) / outerRadius;
    return Vector2Int.down;
  }
  private void Start()
  {
  }

  private void Update()
  {
    Scroll();
    //Zoom();
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
