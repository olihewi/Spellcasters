using System;
using System.Collections;
using System.Collections.Generic;
using Spellcasting;
using UnityEngine;
using UnityEngine.UI;

public class ManaMeter : MonoBehaviour
{
  public Image meterImage;
  public Spellcaster spellcaster;

  private void Update()
  {
    meterImage.fillAmount = spellcaster.currentMana / spellcaster.maxMana;
  }
}
