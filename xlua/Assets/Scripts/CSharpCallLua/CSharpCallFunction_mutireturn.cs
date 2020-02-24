using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

//使用LuaFunction来映射
public class CSharpCallFunction_mutireturn : MonoBehaviour
{
    //使用关键字out
    [CSharpCallLua]
    public delegate void delAddingMutilReturn(int a, int b, out int c, out int d, out int rel);
    public delAddingMutilReturn delFunc;

    [CSharpCallLua]
    public delegate void delAddingMutilReturnRef(ref int a, ref int b, out int c);
    public delAddingMutilReturnRef delRefFunc;

    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.DoString("require 'CallLua'");

        delFunc = env.Global.Get<delAddingMutilReturn>("ProcMyFunc5");

        int rel1 = 0;
        int rel2 = 0;
        int rel3 = 0;

        delFunc(11, 22, out rel1, out rel2, out rel3);
        Debug.Log(string.Format("5 带返回值的-{0}-{1}-{2}", rel1, rel2, rel3));

        //2
        int rel = 0;
        int a = 33;
        int b = 44;
        delRefFunc = env.Global.Get<delAddingMutilReturnRef>("ProcMyFunc5");
        delRefFunc(ref a,ref b,out rel);
        Debug.Log(string.Format("5-2 带返回值的-{0}-{1}-{2}", a, b, rel));
    }


    private void OnDestroy()
    {
        delFunc = null;
        delRefFunc = null;

        if (env != null)
        {
            env.Dispose();
        }
    }

}