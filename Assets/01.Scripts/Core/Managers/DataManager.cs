using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoSingleTon<DataManager>
{
    private string GetFilePath(string path)
    {
        return Path.Combine(Application.persistentDataPath, path);
    }

    private List<IData> _datas = new List<IData>();

    private void SaveData()
    {
        foreach (var data in _datas)
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(GetFilePath(data.FilePath), json);
            Debug.Log("���� ������ �����: " + data.FilePath);
        }
    }

    // ���� ������ �ҷ�����
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
            Debug.Log("���� ������ �ҷ����� ����");
        }
        else
        {
            Debug.Log("����� ������ ����. ���ο� ������ ����");
            Debug.Log(savable.GetType());
            PlayerData playerData = new PlayerData(savable.GetSavableData<PlayerStat>());
            Debug.Log(typeof(G) == playerData.GetType());
            Debug.Log(playerData.PlayerStats.GetType() == savable.GetType());


            data = Activator.CreateInstance(typeof(G), savable) as G;
            if (!_datas.Contains(data))
            {
                Debug.Log("FUck");
                _datas.Add(data);
            }
            SaveData();
        }

        return data;
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

}
