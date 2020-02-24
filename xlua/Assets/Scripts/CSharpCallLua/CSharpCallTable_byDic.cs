using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


//如果lua中的表比較簡單，可以使用dictionary<>,或者list<>之間映射
//优点：编写简单效率不错 缺点：无法映射lua中的复杂table
public class CSharpCallTable_byDic: MonoBehaviour
{
    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.DoString("require 'CallLua'");
        Dictionary<string, string> gl = env.Global.Get<Dictionary<string,string>>("gameLanguage");
        foreach(var i in gl)
        {
            Debug.Log("key:" + i.Key + "-value:" + i.Value);
        }

        Dictionary<string, object> g2 = env.Global.Get<Dictionary<string, object>>("gameUser");
        foreach (var i in g2)
        {
            Debug.Log("2key:" + i.Key + "-2value:" + i.Value);
        }

        List<string> g3 = env.Global.Get<List<string>>("gameSimple");
        foreach (var i in g3)
        {
            Debug.Log("3object" + i.ToString());
        }
    }

    
    private void OnDestroy()
    {
        if (env != null)
        {
            env.Dispose();
        }
    }

}
