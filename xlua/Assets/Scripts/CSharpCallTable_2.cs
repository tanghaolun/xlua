using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


//通过interface映射表
public class CSharpCallTable_2 : MonoBehaviour
{
    [CSharpCallLua]
    public interface IGameLanguage {
        string str1 { get; set; }
        string str2 { get; set; }
    }

    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.DoString("require 'CallLua'");
        IGameLanguage gl = env.Global.Get<IGameLanguage>("gameLanguage");

        Debug.Log("interface--" + gl.str1);
        Debug.Log("interface--" + gl.str2);

        //interface是引用拷贝
        gl.str1 = "copy";

        //lua输出
        env.DoString("print('引用拷贝' .. gameLanguage.str1)");
    }

    
    private void OnDestroy()
    {
        if (env != null)
        {
            env.Dispose();
        }
    }

}
