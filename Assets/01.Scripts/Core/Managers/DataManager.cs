using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Data;

public class DataManager : MonoSingleTon<DataManager>
{
    private string filePath;
    private string FilePath
    {
        get
        {
            if (filePath == null)
            {
                filePath = Path.Combine(Application.persistentDataPath, "PlayerData.json");
            }
            return filePath;
        }
    }

    private PlayerData _playerData;

    public void SavePlayerData()
    {
        string json = JsonUtility.ToJson(_playerData, true);
        File.WriteAllText(FilePath, json);
        Debug.Log("���� ������ �����: " + FilePath);
    }

    // ���� ������ �ҷ�����
    public PlayerData LoadPlayerData(PlayerStat playerStat)
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            _playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("���� ������ �ҷ����� ����");
        }
        else
        {
            Debug.Log("����� ������ ����. ���ο� ������ ����");
            _playerData = new PlayerData(playerStat);
            SavePlayerData();
        }

        return _playerData;
    }

    private void OnApplicationQuit()
    {
        SavePlayerData();
    }

}
