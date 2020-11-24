using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDetect : MonoBehaviour
{
    public bool nearRock = false;

    public void SetNearRock()
    {
        nearRock = true;
        Debug.Log(nearRock);
    }

    public void SetAwayRock()
    {
        nearRock = false;
        Debug.Log(nearRock);
    }


        

}
