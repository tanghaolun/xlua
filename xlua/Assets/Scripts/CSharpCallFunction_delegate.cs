using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


//如果lua中的表比較簡單，可以使用dictionary<>,或者list<>之間映射
//优点：编写简单效率不错 缺点：无法映射lua中的复杂table
public class CSharpCallFunction_delegate: MonoBehaviour
{

    public delegate void delAdding(int a, int b);
    Action act = null;
    delAdding act1 = null;

    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.DoString("require 'CallLua'");

        act = env.Global.Get<Action>("ProcMyFunc1");
        act.Invoke();
        
    }


    private void OnDestroy()
    {
        act = null;
        act1 = null;

        if (env != null)
        {
            env.Dispose();
        }
    }

}
