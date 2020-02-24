

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


//如果lua中的表比較簡單，可以使用dictionary<>,或者list<>之間映射
//优点：编写简单效率不错 缺点：无法映射lua中的复杂table
public class CSharpCallFunction_delegate : MonoBehaviour
{

    public delegate void delAdding(int a, int b);
    Action act = null;
    delAdding act1 = null;
    Action<int, int, int> act3 = null;
    Func<int, int, int> act4 = null; //带一个返回值的

    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.DoString("require 'CallLua'");

        //1
        act = env.Global.Get<Action>("ProcMyFunc1");
        act.Invoke();

        //2
        act1 = env.Global.Get<delAdding>("ProcMyFunc2");
        act1(3, 4);

        //3
        act3 = env.Global.Get<Action<int, int, int>>("ProcMyFunc4");
        act3(3, 4, 5);

        //4 带返回值的
        act4 = env.Global.Get<Func<int, int, int>>("ProcMyFunc3");
        int rel = act4(10, 20);
        Debug.Log("4 带返回值的-" + rel);
    }


    private void OnDestroy()
    {
        act = null;
        act1 = null;
        act3 = null;
        act4 = null;

        if (env != null)
        {
            env.Dispose();
        }
    }

}

