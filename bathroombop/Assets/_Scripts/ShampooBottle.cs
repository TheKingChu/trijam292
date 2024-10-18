using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShampooBottle : CreatureBase
{
    private int bopCount = 0;
    private int requiredBops = 2;

    protected override void Bop()
    {
        bopCount++;
        if(bopCount >= requiredBops)
        {
            base.Bop();
            bopCount = 0;
        }
        else
        {
            Debug.Log("shampoo bottle partially bopped");
        }
    }
}
