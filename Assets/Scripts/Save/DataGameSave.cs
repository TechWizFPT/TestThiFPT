using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataGameSave
{
    public static DataGameInit data;
     const string path = "/save.txt";
    public static void Init()
    {
        if(System.IO.File.Exists(Application.persistentDataPath + path))
        {
            data = JsonUtility.FromJson<DataGameInit>(File.ReadAllText(Application.persistentDataPath + path));
        }
        else
        {
      
            if (data == null)
            {
                //create
                data = new DataGameInit();
                Save();
            }
        }
      
    }
    public static void Save()
    {
        File.WriteAllText(Application.persistentDataPath+ path, JsonUtility.ToJson(data));    
    }
    public static void Load()
    {
        data = JsonUtility.FromJson<DataGameInit>(File.ReadAllText(Application.persistentDataPath));
    }
}
