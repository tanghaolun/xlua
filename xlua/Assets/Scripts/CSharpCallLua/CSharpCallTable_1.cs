using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CSharpCallTable_1 : MonoBehaviour
{

    public class GameLanguage {
        public string str1;
        public string str2;
    }

    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.DoString("require 'CallLua'");
        GameLanguage gl = env.Global.Get<GameLanguage>("gameLanguage");

        Debug.Log(gl.str1);
        Debug.Log(gl.str2);

        //interface是引用拷贝
        gl.str1 = "copy";

        //lua输出
        env.DoString("print('值拷贝' .. gameLanguage.str1)");
    }

    private void OnDestroy()
    {
        if (env != null)
        {
            env.Dispose();
        }
    }

}
