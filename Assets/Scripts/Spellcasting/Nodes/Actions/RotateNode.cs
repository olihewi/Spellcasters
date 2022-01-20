using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
  public class RotateNode : Node
  {
    public override void Execute()
    {
      if (!(inputs[0].value is Rigidbody rb)) return;
      if (!(inputs[1].value is Vector3 v)) return;
      if (rb.CompareTag("Player"))
      {
        Transform camera = rb.GetComponent<Player>().cameraTransform.transform;
        rb.transform.Rotate(Vector3.up,v.x * Time.deltaTime, Space.Self);
        camera.Rotate(Vector3.left, v.y * Time.deltaTime, Space.Self);
      }
      else
      {
        rb.transform.Rotate(v * Time.deltaTime);
      }
    }
  }
}

