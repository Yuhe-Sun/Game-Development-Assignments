﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloLua : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XLua.LuaEnv luaenv = new XLua.LuaEnv();
        luaenv.DoString("CS.UnityEngine.Debug.Log('Hello Lua')");
        luaenv.DoString("CS.UnityEngine.Debug.Log('Hello World')");
        luaenv.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
