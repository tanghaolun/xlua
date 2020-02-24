using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class RunLuaFiles: MonoBehaviour
{

    //xlua的环境核心类
    LuaEnv env = null;

    // Start is called before the first frame update
    private void Start()
    {
        env = new LuaEnv();
        env.AddLoader(CustomMyloader);

        //Test
        env.DoString("require 'CustomPrint'");
    }

    private byte[] CustomMyloader(ref string filename)
    {
        byte[] byArray = null;
        string luapath = Application.dataPath + "/Scripts/lua/" + filename + ".lua";
        string strluacontent = File.ReadAllText(luapath);
        byArray = System.Text.Encoding.UTF8.GetBytes(strluacontent);
        return byArray;
    }

    private void OnDestroy()
    {
        if(env != null)
        {
            env.Dispose();
        }
    }

}
