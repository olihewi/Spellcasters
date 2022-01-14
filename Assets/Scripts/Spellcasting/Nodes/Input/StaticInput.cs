using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInput : MonoBehaviour
{
    public static MasterInput input;

    private void Awake()
    {
        input = new MasterInput();
        input.Enable();
    }
}
