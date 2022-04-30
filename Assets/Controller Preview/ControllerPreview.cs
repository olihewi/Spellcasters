using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPreview : MonoBehaviour
{
  [Serializable]
  public struct Controller
  {
    public RectTransform a;
    public RectTransform b;
    public RectTransform x;
    public RectTransform y;
    
    public RectTransform up;
    public RectTransform down;
    public RectTransform left;
    public RectTransform right;
    
    public RectTransform leftShoulder;
    public RectTransform rightShoulder;
    
    public RectTransform start;
    public RectTransform select;
    
    public RectTransform leftStick;
    public RectTransform rightStick;
  }

  public Controller controller;
  public float stickAmount = 20.0F;

  private Vector2 leftStickStart;
  private Vector2 rightStickStart;

  private void Start()
  {
    leftStickStart = controller.leftStick.position;
    rightStickStart = controller.rightStick.position;
  }

  private void Update()
  {
    Gamepad gamepad = Gamepad.current;
    if (gamepad == null) return;
    
    controller.a.gameObject.SetActive(gamepad.aButton.isPressed);
    controller.b.gameObject.SetActive(gamepad.bButton.isPressed);
    controller.x.gameObject.SetActive(gamepad.xButton.isPressed);
    controller.y.gameObject.SetActive(gamepad.yButton.isPressed);
    
    controller.up.gameObject.SetActive(gamepad.dpad.up.isPressed);
    controller.down.gameObject.SetActive(gamepad.dpad.down.isPressed);
    controller.left.gameObject.SetActive(gamepad.dpad.left.isPressed);
    controller.right.gameObject.SetActive(gamepad.dpad.right.isPressed);
    
    controller.leftShoulder.gameObject.SetActive(gamepad.leftShoulder.isPressed);
    controller.rightShoulder.gameObject.SetActive(gamepad.rightShoulder.isPressed);
    
    controller.start.gameObject.SetActive(gamepad.startButton.isPressed);
    controller.select.gameObject.SetActive(gamepad.selectButton.isPressed);
    
    controller.leftStick.gameObject.SetActive(gamepad.leftStickButton.isPressed);
    controller.rightStick.gameObject.SetActive(gamepad.rightStickButton.isPressed);
    controller.leftStick.parent.position = leftStickStart + gamepad.leftStick.ReadValue() * stickAmount;
    controller.rightStick.parent.position = rightStickStart + gamepad.rightStick.ReadValue() * stickAmount;
  }
}
