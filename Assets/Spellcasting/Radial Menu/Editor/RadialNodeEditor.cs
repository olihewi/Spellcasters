using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Spellcasting.Nodes.Actions;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RadialNode))]
public class RadialNodeEditor : Editor
{
  public RadialNode node
  {
    get { return (RadialNode) target; }
  }

  private void OnEnable()
  {
    node.RegisterType();
  }

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    EditorGUILayout.Space(10);
    string newClassName = EditorGUILayout.TextField("Class Name", node.className);
    if (newClassName != node.className)
    {
      node.className = newClassName;
      node.RegisterType();
    }
    if (node.type == null)
     EditorGUILayout.HelpBox("This type does not exist!", MessageType.Error);
  }
}
