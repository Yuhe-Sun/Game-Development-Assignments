﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProperties : MonoBehaviour
{
    [NonSerialized]
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
