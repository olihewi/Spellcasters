using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spellcasting.Nodes.Actions
{
  public class RotateNode : Node
  {
    public override void Tick()
    {
      if (inputs[2].output is bool b && !b) return;
      if (!(inputs[0].output is Rigidbody rb)) return;
      if (!(inputs[1].output is Vector3 v)) return;
      if (rb.CompareTag("Player"))
      {
        Transform camera = owner.GetComponent<Player>().cameraRef.transform;
        rb.transform.Rotate(Vector3.up,v.x * Time.deltaTime, Space.Self);
        camera.Rotate(Vector3.left, v.z * Time.deltaTime, Space.Self);
      }
      else
      {
        rb.transform.Rotate(v * Time.deltaTime);
      }
    }
  }
}

