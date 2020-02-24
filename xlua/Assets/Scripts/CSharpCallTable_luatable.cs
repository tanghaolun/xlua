using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


//如果lua中的表比較簡單，可以使用dictionary<>,或者list<>之間映射
//优点：编写简单效率不错 缺点：无法映射lua中的复杂table
public class CSharpCallTable_luatable: MonoBehaviour
{
    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.DoString("require 'CallLua'");
        XLua.LuaTable gl = env.Global.Get<XLua.LuaTable>("gameUser");

        Debug.Log("luatable---" + gl.Get<string>("name"));

        //函数
        XLua.LuaFunction fun = gl.Get<XLua.LuaFunction>("Speak");
        fun.Call();
        XLua.LuaFunction fun1 = gl.Get<XLua.LuaFunction>("Caculation");
        object[] objarray =  fun1.Call(gl, 2, 3);
        Debug.Log("result--" + objarray[0]);
    }


    private void OnDestroy()
    {
        if (env != null)
        {
            env.Dispose();
        }
    }

}
