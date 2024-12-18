using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoSingleTon<DataManager>
{
    private string GetFilePath(string path)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, path);

        string directory = Path.GetDirectoryName(fullPath);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        return fullPath;
    }

    private List<IData> _datas = new List<IData>();

    private void SaveData()
    {
        foreach (var data in _datas)
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(GetFilePath(data.FilePath), json);
            Debug.Log("게임 데이터 저장됨: " + data.FilePath);
        }
    }

    // 게임 데이터 불러오기
    public G LoadData<T, G>(T savable) where T : class, ISavable where G : class, IData
    {
        G data;

        if (File.Exists(GetFilePath(savable.FilePath)))
        {
            string json = File.ReadAllText(GetFilePath(savable.FilePath));
            data = JsonUtility.FromJson<G>(json);
            if (!_datas.Contains(data))
            {
                _datas.Add(data);
            }
        }
        else
        {
            data = Activator.CreateInstance(typeof(G), savable) as G;
            if (!_datas.Contains(data))
            {
                _datas.Add(data);
            }
            SaveData();
        }

        return data;
    }

    public List<G> LoadDatas<T, G>(List<T> savables) where T : class, ISavable where G : class, IData
    {
        List<G> datas = new List<G>();

        foreach (T savable in savables)
        {
            G data;

            if (File.Exists(GetFilePath(savable.FilePath)))
            {
                string json = File.ReadAllText(GetFilePath(savable.FilePath));
                data = JsonUtility.FromJson<G>(json);
                if (!_datas.Contains(data))
                {
                    _datas.Add(data);
                }
            }
            else
            {
                data = Activator.CreateInstance(typeof(G), savable) as G;
                if (!_datas.Contains(data))
                {
                    _datas.Add(data);
                }
                SaveData();
            }
            datas.Add(data);
        }

        return datas;
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

}
