using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConjureLineManager : MonoBehaviour
{
  public static ConjureLineManager Instance;
  public LineRenderer lineRendererPrefab;
  public int maxLineRenderers = 10;

  private LineRenderer[] rendererPool;

  private int poolIndex = 0;

  private void Awake()
  {
    Instance = this;
    rendererPool = new LineRenderer[maxLineRenderers];
    for (int i = 0; i < maxLineRenderers; i++)
    {
      rendererPool[i] = Instantiate(lineRendererPrefab, transform);
    }
  }

  public void ConjureLine(Vector3 _start, Vector3 _end)
  {
    LineRenderer line = rendererPool[poolIndex++];
    line.gameObject.SetActive(true);
    line.SetPosition(0,_start);
    line.SetPosition(1,_end);
  }

  private void Update()
  {
    foreach (LineRenderer line in rendererPool)
    {
      line.gameObject.SetActive(false);
    }
    poolIndex = 0;
  }
}