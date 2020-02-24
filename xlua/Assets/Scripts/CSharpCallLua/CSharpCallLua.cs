using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CSharpCallLua : MonoBehaviour
{
    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.DoString("require 'CallLua'");

        string str = env.Global.Get<string>("str");
        int num = env.Global.Get<int>("number");
        float fnum = env.Global.Get<int>("floNumber");
        bool b = env.Global.Get<bool>("IsFirstTime");

        Debug.Log(str);
        Debug.Log(num);
        Debug.Log(fnum);
        Debug.Log(b);
    }

    private void OnDestroy()
    {
        if (env != null)
        {
            env.Dispose();
        }
    }

}
