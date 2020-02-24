using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


//通过interface映射表
public class CSharpCallTable_3 : MonoBehaviour
{
    [CSharpCallLua]
    public interface IGameUser {
        string name { get; set; }
        string age { get; set; }

        void Speak();
        int Caculation(int a, int b);
    }

    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.DoString("require 'CallLua'");
        IGameUser gl = env.Global.Get<IGameUser>("gameUser");

        Debug.Log("interface--" + gl.name);
        Debug.Log("interface--" + gl.age);

        gl.Speak();
        Debug.Log("interface--" + gl.Caculation(100,200));

    }

    
    private void OnDestroy()
    {
        if (env != null)
        {
            env.Dispose();
        }
    }

}
