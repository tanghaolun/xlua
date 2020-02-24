using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

//使用LuaFunction来映射
public class CSharpCallFunction_luafunc : MonoBehaviour
{

    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.DoString("require 'CallLua'");

        //1
        LuaFunction func1 = env.Global.Get<LuaFunction>("ProcMyFunc1");
        func1.Call();

        //3
        LuaFunction func3 = env.Global.Get<LuaFunction>("ProcMyFunc3");
        object[] objarray = func3.Call(12,21);
        int rel = int.Parse(objarray[0].ToString());
        Debug.Log("3 带返回值的-" + rel);

        //5
        LuaFunction func5 = env.Global.Get<LuaFunction>("ProcMyFunc5");
        object[] objarray5 = func5.Call(22, 33);
        Debug.Log(string.Format("5 带返回值的-{0}-{1}-{2}",objarray5[0], objarray5[1], objarray5[2]));

    }


    private void OnDestroy()
    {

        if (env != null)
        {
            env.Dispose();
        }
    }

}