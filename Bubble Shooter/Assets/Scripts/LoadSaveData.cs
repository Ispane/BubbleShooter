using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadSaveData : MonoBehaviour
{
    [SerializeField] private int _levelsCount;
    public static List<int> marks = new List<int>();

    private void Start()
    {
       LoadData();

        if (marks.Count == 0)
        {
            for (int i = 0; i < _levelsCount; i++)
            {
                marks.Add(0);
            }
        }
    }

    public static void SaveData()
    {
        var data = new Data()
        {
            Marks = marks
        };

        string file_path = Application.persistentDataPath + "/gamedata.mine";

        string serialized = JsonUtility.ToJson(data);
        File.WriteAllText(file_path, serialized);
    }

    public void LoadData()
    {
        string file_path = Application.persistentDataPath + "/gamedata.mine";

        if (File.Exists(file_path))
        {
            string loaded_data = File.ReadAllText(file_path);
            Data deserialized = JsonUtility.FromJson<Data>(loaded_data);
            marks = deserialized.Marks;
        }
    }
}

[Serializable]
public class Data
{
    public List<int> Marks;
}
