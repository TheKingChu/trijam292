using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapBar : CreatureBase
{
    public SoapBar()
    {
        popupTime = 1f;
        popdownTime = 0.5f;
    }

    protected override void Bop()
    {
        base.Bop();
        Debug.Log("soap bar bopped");
    }
}
